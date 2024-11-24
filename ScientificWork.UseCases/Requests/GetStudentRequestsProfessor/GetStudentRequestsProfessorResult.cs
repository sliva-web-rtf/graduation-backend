using ScientificWork.UseCases.Common.Pagination;
using ScientificWork.UseCases.Requests.Common.Dtos;

namespace ScientificWork.UseCases.Requests.GetStudentRequestsProfessor;

public class GetStudentRequestsProfessorResult
{
    public PagedList<RequestDto> Requests { get; init; }

    public int Page { get; init; }

    public int Length { get; init; }
}
