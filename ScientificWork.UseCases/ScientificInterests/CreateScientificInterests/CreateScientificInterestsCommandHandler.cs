using ClosedXML.Excel;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using MediatR;
using ScientificWork.Domain.ScientificInterests;
using ScientificWork.Infrastructure.Abstractions.Interfaces;

namespace ScientificWork.UseCases.ScientificInterests.CreateScientificInterests;

public class CreateScientificInterestsCommandHandler : IRequestHandler<CreateScientificInterestsCommand>
{
    private readonly IAppDbContext dbContext;

    /// <summary>
    /// Constructor.
    /// </summary>
    public CreateScientificInterestsCommandHandler(IAppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    /// <inheritdoc />
    public async Task Handle(CreateScientificInterestsCommand request, CancellationToken cancellationToken)
    {
        using var stream = new MemoryStream();
        await request.File.CopyToAsync(stream, cancellationToken);

        using var workbook= new XLWorkbook(stream);
        var ws = workbook.Worksheet(1);
        var countRow = ws.Rows().Count();
        var scientificInterests = new List<ScientificInterest>();
        for (var i = 1; i < countRow; i++)
        {
            var name = ws.Cell($"A{i}").GetValue<string>();
            name = name.Split()[0].Count(x => x == '.') == 2 ? string.Join(" ", name.Split().Skip(1)) : name;
            scientificInterests.Add(new ScientificInterest(name));
        }

        await dbContext.ScientificInterests.AddRangeAsync(scientificInterests, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
