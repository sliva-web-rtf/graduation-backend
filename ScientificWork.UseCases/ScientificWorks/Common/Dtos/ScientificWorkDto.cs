using ScientificWork.Domain.ScientificWorks.Enums;

namespace ScientificWork.UseCases.ScientificWorks.Common.Dtos;

public class ScientificWorkDto
{
    public Guid Id { get; init; }

    public string Name { get; init; }

    public string Titile { get; init; }

    public int? Limit { get; init; }

    public int? Fullness { get; init; }

    public IList<string> ScientificInterests { get; init; }

    public WorkStatus WorkStatus { get; init; }
}
