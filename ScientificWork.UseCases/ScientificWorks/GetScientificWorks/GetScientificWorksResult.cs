using ScientificWork.UseCases.Common.Pagination;
using ScientificWork.UseCases.ScientificWorks.Common.Dtos;

namespace ScientificWork.UseCases.ScientificWorks.GetScientificWorksForProfessor;

public class GetScientificWorksResult
{
    public PagedList<ScientificWorkDto> ScientificWorks { get; init; }

    public int Page { get; init; }

    public int Length { get; init; }
}
