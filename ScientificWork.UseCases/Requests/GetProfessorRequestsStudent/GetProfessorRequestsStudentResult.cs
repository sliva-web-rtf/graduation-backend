using ScientificWork.Infrastructure.Tools.Common.Pagination;
using ScientificWork.UseCases.Requests.Common.Dtos;

namespace ScientificWork.UseCases.Requests.GetProfessorRequestsStudent;

public class GetProfessorRequestsStudentResult
{
    public PagedList<RequestDto> Requests { get; init; }

    public int Page { get; init; }

    public int Length { get; init; }
}
