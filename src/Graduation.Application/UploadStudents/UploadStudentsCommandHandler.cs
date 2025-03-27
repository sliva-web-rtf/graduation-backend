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
        var ws = workbook.Worksheet(1);
        var countRow = ws.Rows().Count();
        var studentsGroup = ws.Cell("B2").GetValue<string>();
        for (var i = 4; i <= countRow; i++)
        {
            var fullName = ws.Cell($"D{i}").GetValue<string>();
            var role = ws.Cell($"G{i}").GetValue<string>();

            if (string.IsNullOrWhiteSpace(fullName) || string.IsNullOrWhiteSpace(role))
            {
                continue;
            }
            
            var splitFullName = fullName.Split();
            var (lastName, firstName, patronymic) = (splitFullName[0], splitFullName[1], splitFullName[2]);
            var result =
                await sender.Send(new CreateUserCommand(fullName.Replace(" ", "") + studentsGroup.Replace("-", ""), null, "Aa1234#", firstName, lastName, patronymic, null, role),
                    cancellationToken);
            if (result.UserId == default)
            {
                continue;
            }
            userAccessor.UserId = result.UserId;
        }
    }
}