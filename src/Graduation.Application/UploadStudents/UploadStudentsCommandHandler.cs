using MediatR;
using ClosedXML.Excel;
using Graduation.Application.Users.CreateUser;
using Graduation.Application.Users.AddUserToRole;
using Graduation.Application.Interfaces.Services;
using Graduation.Application.Interfaces.DataAccess;
using Graduation.Application.Interfaces.Authentication;
using Graduation.Domain;
using Graduation.Domain.Users;
using Graduation.Domain.AcademicGroups;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Graduation.Application.UploadStudents;

public class UploadStudentsCommandHandler : IRequestHandler<UploadStudentsCommand>
{
    private readonly ICurrentYearProvider currentYearProvider;
    private readonly ISender sender;
    private readonly ILoggedUserAccessor userAccessor;
    private readonly UserManager<User> userManager;
    private readonly IAppDbContext dbContext;

    public UploadStudentsCommandHandler(
        ISender sender,
        ILoggedUserAccessor userAccessor,
        UserManager<User> userManager,
        IAppDbContext dbContext,
        ICurrentYearProvider currentYearProvider)
    {
        this.sender = sender;
        this.userAccessor = userAccessor;
        this.userManager = userManager;
        this.dbContext = dbContext;
        this.currentYearProvider = currentYearProvider;
    }

    public async Task Handle(UploadStudentsCommand request, CancellationToken cancellationToken)
    {
        using var stream = new MemoryStream();
        await request.File.CopyToAsync(stream, cancellationToken);

        using var workbook = new XLWorkbook(stream);
        var countWs = workbook.Worksheets.Count;

        for (var k = 4; k <= 23; k++)
        {
            var ws = workbook.Worksheet(k);
            var countRow = ws.Rows().Count();
            var studentsGroup = ws.Cell("B2").GetValue<string>();

            if (string.IsNullOrWhiteSpace(studentsGroup))
            {
                continue;
            }

            for (var i = 4; i <= countRow; i++)
            {
                var fullName = ws.Cell($"D{i}").GetValue<string>().Trim();
                var role = ws.Cell($"G{i}").GetValue<string>();

                if (string.IsNullOrWhiteSpace(fullName) || string.IsNullOrWhiteSpace(role))
                {
                    continue;
                }

                var splitFullName = fullName.Split();
                var (lastName, firstName, patronymic) = (string.Empty, string.Empty, string.Empty);

                if (splitFullName.Length < 3)
                {
                    (lastName, firstName) = (splitFullName[0], splitFullName[1]);
                }
                else
                {
                    (lastName, firstName, patronymic) = (splitFullName[0], splitFullName[1], splitFullName[2]);
                }

                var userName = fullName.Replace(" ", "") + studentsGroup.Replace("-", "");

                var user = await userManager.FindByNameAsync(userName);
                var userId = user.Id;

                if (user.Equals(null))
                {
                    userId =
                        (await sender.Send(new CreateUserCommand(userName,
                                null,
                                "Aa1234#", firstName, lastName, patronymic, null, null),
                            cancellationToken)).UserId;
                }

                user = userManager.FindByIdAsync(userId.ToString()).Result;

                if (!await userManager.IsInRoleAsync(user, WellKnownRoles.Student))
                {
                    await sender.Send(new AddUserToRoleCommand(userId, WellKnownRoles.Student),
                        cancellationToken);
                }

                var academicGroup = dbContext.AcademicGroups.SingleOrDefault(x => x.Name.Equals(studentsGroup));

                if (academicGroup == null)
                {
                    academicGroup = new AcademicGroup(Guid.NewGuid())
                    {
                        Name = studentsGroup,
                        Year = currentYearProvider.GetCurrentYear()
                    };
                    dbContext.AcademicGroups.Add(academicGroup);
                    await dbContext.SaveChangesAsync(cancellationToken);
                }

                var student = await dbContext.Students.FirstOrDefaultAsync(x => x.Id == userId,
                    cancellationToken);
                student.AcademicGroupId = academicGroup.Id;
                await dbContext.SaveChangesAsync(cancellationToken);
            }
        }
    }
}