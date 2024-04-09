using ClosedXML.Excel;
using MediatR;
using ScientificWork.UseCases.Professors.CreateProfessor;

namespace ScientificWork.UseCases.Professors.UplaodProfessors;

public class UploadProfessorsCommandHandler : IRequestHandler<UploadProfessorsCommand>
{
    private readonly ISender sender;

    public UploadProfessorsCommandHandler(ISender sender)
    {
        this.sender = sender;
    }

    public async Task Handle(UploadProfessorsCommand request, CancellationToken cancellationToken)
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
            if (!string.IsNullOrWhiteSpace(name) && !string.IsNullOrWhiteSpace(password))
            {
                await sender.Send(new CreateProfessorCommand(name, password), cancellationToken);
            }
        }
    }
}
