using ScientificWork.Infrastructure.Tools.Common.Pagination;
using ScientificWork.UseCases.ScientificWorks.Common.Dtos;

namespace ScientificWork.UseCases.ScientificWorks.GetScientificWorks;

public class GetScientificWorksResult
{
    public PagedList<ScientificWorkDto> ScientificWorks { get; init; }

    public int Page { get; init; }

    public int Length { get; init; }
}
