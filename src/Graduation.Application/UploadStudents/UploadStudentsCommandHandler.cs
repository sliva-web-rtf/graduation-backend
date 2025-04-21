using ClosedXML.Excel;
using Graduation.Application.Interfaces.DataAccess;
using Graduation.Application.Interfaces.Services;
using Graduation.Application.Users.AddUserToRole;
using Graduation.Application.Users.CreateUser;
using Graduation.Domain;
using Graduation.Domain.Users;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Graduation.Application.UploadStudents;

public class UploadStudentsCommandHandler : IRequestHandler<UploadStudentsCommand>
{
    private readonly ICurrentYearProvider currentYearProvider;
    private readonly IAppDbContext dbContext;
    private readonly ISender sender;
    private readonly UserManager<User> userManager;

    public UploadStudentsCommandHandler(
        ISender sender,
        UserManager<User> userManager,
        IAppDbContext dbContext,
        ICurrentYearProvider currentYearProvider)
    {
        this.sender = sender;
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

        var ws = workbook.Worksheet(1);
        var countRow = ws.Rows().Count();

        for (var i = 1; i < countRow + 1; i++)
        {
            var fullName = ws.Cell($"B{i}").GetValue<string>().Trim();
            var group = ws.Cell($"A{i}").GetValue<string>().Trim();

            if (string.IsNullOrWhiteSpace(fullName)) continue;

            var splitFullName = fullName.Split();
            var (lastName, firstName, patronymic) = (string.Empty, string.Empty, string.Empty);

            if (splitFullName.Length < 3)
                (lastName, firstName) = (splitFullName[0], splitFullName[1]);
            else if (splitFullName.Length > 3)
                lastName = fullName;
            else
                (lastName, firstName, patronymic) = (splitFullName[0], splitFullName[1], splitFullName[2]);

            var userName = fullName.Replace(" ", "") + group.Replace("-", "");

            var user = await userManager.FindByNameAsync(userName);
            var userId = user?.Id ?? Guid.Empty;

            if (user is null)
                userId =
                    (await sender.Send(new CreateUserCommand(userName,
                            null,
                            "Aa1234#", firstName, lastName, patronymic, null, null),
                        cancellationToken)).UserId;
            else
            {
                user.FirstName = firstName;
                user.LastName = lastName;
                user.Patronymic = patronymic;
                await dbContext.SaveChangesAsync();
            }

            user = userManager.FindByIdAsync(userId.ToString()).Result;

            if (!await userManager.IsInRoleAsync(user, WellKnownRoles.Student))
                await sender.Send(new AddUserToRoleCommand(userId, WellKnownRoles.Student),
                    cancellationToken);
        }
    }
}