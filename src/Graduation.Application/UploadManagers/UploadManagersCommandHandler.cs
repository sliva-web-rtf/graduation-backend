using MediatR;
using ClosedXML.Excel;
using Graduation.Application.Users.CreateUser;
using Graduation.Application.Users.AddUserToRole;
using Graduation.Application.Interfaces.Authentication;
using Graduation.Domain;
using Graduation.Domain.Users;
using Microsoft.AspNetCore.Identity;

namespace Graduation.Application.UploadManagers;

public class UploadManagersCommandHandler : IRequestHandler<UploadManagersCommand>
{
    private readonly ISender sender;
    private readonly UserManager<User> userManager;

    public UploadManagersCommandHandler(ISender sender, ILoggedUserAccessor userAccessor, UserManager<User> userManager)
    {
        this.sender = sender;
        this.userManager = userManager;
    }

    public async Task Handle(UploadManagersCommand request, CancellationToken cancellationToken)
    {
        using var stream = new MemoryStream();
        await request.File.CopyToAsync(stream, cancellationToken);

        using var workbook = new XLWorkbook(stream);

        var ws = workbook.Worksheet(1);
        var countRow = ws.Rows().Count();

        for (var i = 1; i <= countRow; i++)
        {
            var fullName = ws.Cell($"A{i}").GetValue<string>().Trim();
            var contacts = ws.Cell($"B{i}").GetValue<string>();

            if (string.IsNullOrWhiteSpace(fullName))
            {
                continue;
            }

            var parsedContacts = string.Empty;
            if (!string.IsNullOrWhiteSpace(contacts))
            {
                parsedContacts = contacts
                    .Split()
                    .Where(contact => contact != string.Empty)
                    .Select(contact => contact.Trim())
                    .Aggregate((firstContact, secondContact) => $"{firstContact} {secondContact}");
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

            var userName = fullName.Replace(" ", "");
            var user = await userManager.FindByNameAsync(userName);
            var userId = user?.Id;

            if (user == null)
            {
                userId =
                    (await sender.Send(new CreateUserCommand(userName,
                            null,
                            "Aa1234#", firstName, lastName, patronymic, parsedContacts, null),
                        cancellationToken)).UserId;
            }
            user = userManager.FindByIdAsync(userId.ToString()).Result;

            if (!await userManager.IsInRoleAsync(user, WellKnownRoles.Supervisor))
            {
                await sender.Send(new AddUserToRoleCommand(userId.Value, WellKnownRoles.Supervisor),
                    cancellationToken);
            }
        }
    }
}