using ClosedXML.Excel;
using Graduation.Application.Interfaces.Authentication;
using Graduation.Application.Users.CreateUser;
using MediatR;

namespace Graduation.Application.UploadManagers;

public class UploadManagersCommandHandler : IRequestHandler<UploadManagersCommand>
{
    private readonly ISender sender;
    private readonly ILoggedUserAccessor userAccessor;

    public UploadManagersCommandHandler(ISender sender, ILoggedUserAccessor userAccessor)
    {
        this.sender = sender;
        this.userAccessor = userAccessor;
    }

    public async Task Handle(UploadManagersCommand request, CancellationToken cancellationToken)
    {
        using var stream = new MemoryStream();
        await request.File.CopyToAsync(stream, cancellationToken);

        using var workbook = new XLWorkbook(stream);

        var ws = workbook.Worksheet(2);
        var countRow = ws.Rows().Count();

        for (var i = 2; i <= countRow; i++)
        {
            var fullName = ws.Cell($"B{i}").GetValue<string>().Trim();
            var contacts = ws.Cell($"E{i}").GetValue<string>();

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

            var result =
                await sender.Send(new CreateUserCommand(fullName.Replace(" ", ""),
                        null,
                        "Aa1234#", firstName, lastName, patronymic, parsedContacts, null),
                    cancellationToken);

            if (result.UserId == default)
            {
                continue;
            }
            userAccessor.UserId = result.UserId;
        }
    }
}