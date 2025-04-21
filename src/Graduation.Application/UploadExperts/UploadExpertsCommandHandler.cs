using ClosedXML.Excel;
using Graduation.Domain;
using Graduation.Domain.Users;
using Graduation.Application.Users.CreateUser;
using Graduation.Application.Users.AddUserToRole;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Graduation.Application.UploadExperts;

public class UploadExpertsCommandHandler : IRequestHandler<UploadExpertsCommand>
{
    private readonly ISender sender;
    private readonly UserManager<User> userManager;

    public UploadExpertsCommandHandler(ISender sender, UserManager<User> userManager)
    {
        this.sender = sender;
        this.userManager = userManager;
    }

    public async Task Handle(UploadExpertsCommand request, CancellationToken cancellationToken)
    {
        using var stream = new MemoryStream();
        await request.File.CopyToAsync(stream, cancellationToken);

        using var workbook = new XLWorkbook(stream);
        var ws = workbook.Worksheet(1);
        var countRow = ws.Rows().Count();

        for (var i = 2; i < countRow + 2; i++)
        {
            var fullName = ws.Cell($"A{i}").GetValue<string>().Trim();
            var contacts = ws.Cell($"B{i}").GetValue<string>();

            if (string.IsNullOrWhiteSpace(fullName))
            {
                continue;
            }

            var (lastName, firstName, patronymic) = (string.Empty, string.Empty, string.Empty);
            var splitFullName = fullName.Split();

            if (splitFullName.Length < 3)
            {
                (lastName, firstName) = (splitFullName[0], splitFullName[1]);
            }
            else
            {
                (lastName, firstName, patronymic) = (splitFullName[0], splitFullName[1], splitFullName[2]);
            }

            var userName = fullName.Replace(" ", "");
            var user = await userManager.FindByNameAsync(userName);
            var userId = user?.Id ?? Guid.Empty;

            if (user is null)
            {
                userId =
                    (await sender.Send(new CreateUserCommand(userName,
                            null,
                            "Aa1234#", firstName, lastName, patronymic, contacts, null),
                        cancellationToken)).UserId;
            }

            user = userManager.FindByIdAsync(userId.ToString()).Result;
            const string role = WellKnownRoles.Expert;
            
            if (!await userManager.IsInRoleAsync(user, role))
            {
                await sender.Send(new AddUserToRoleCommand(userId, role),
                    cancellationToken);
            }
        }
    }
}