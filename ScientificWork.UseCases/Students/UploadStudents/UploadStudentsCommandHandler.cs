using ClosedXML.Excel;
using MediatR;
using ScientificWork.UseCases.Students.CreateStudent;

namespace ScientificWork.UseCases.Students.UploadStudents;

public class UploadStudentsCommandHandler : IRequestHandler<UploadStudentsCommand>
{
    private readonly ISender sender;

    public UploadStudentsCommandHandler(ISender sender)
    {
        this.sender = sender;
    }

    public async Task Handle(UploadStudentsCommand request, CancellationToken cancellationToken)
    {
        using var stream = new MemoryStream();
        await request.File.CopyToAsync(stream, cancellationToken);

        using var workbook = new XLWorkbook(stream);
        var ws = workbook.Worksheet(1);
        var countRow = ws.Rows().Count();
        for (var i = 1; i <= countRow; i++)
        {
            var name = ws.Cell($"A{i}").GetValue<string>();
            var password = ws.Cell($"B{i}").GetValue<string>();
            await sender.Send(new CreateStudentCommand(name, password), cancellationToken);
        }
    }
}
