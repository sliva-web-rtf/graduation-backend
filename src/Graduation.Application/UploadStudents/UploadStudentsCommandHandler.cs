using ClosedXML.Excel;
using Graduation.Application.Interfaces.Authentication;
using Graduation.Application.Users.CreateUser;
using MediatR;

namespace Graduation.Application.UploadStudents;

public class UploadStudentsCommandHandler : IRequestHandler<UploadStudentsCommand>
{
    private readonly ISender sender;
    private readonly ILoggedUserAccessor userAccessor;

    public UploadStudentsCommandHandler(ISender sender, ILoggedUserAccessor userAccessor)
    {
        this.sender = sender;
        this.userAccessor = userAccessor;
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
                
                var result =
                    await sender.Send(new CreateUserCommand(fullName.Replace(" ", "") + studentsGroup.Replace("-", ""),
                            null,
                            "Aa1234#", firstName, lastName, patronymic, null, null),
                        cancellationToken);
                
                if (result.UserId == default)
                {
                    continue;
                }
                userAccessor.UserId = result.UserId;
            }
        }
    }
}