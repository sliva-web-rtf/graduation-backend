using ScientificWork.Infrastructure.Tools.Common.Pagination;
using ScientificWork.UseCases.Requests.Common.Dtos;

namespace ScientificWork.UseCases.Requests.GetStudentRequestsStudent;

public class GetStudentRequestsStudentResult
{
    public PagedList<RequestDto> Requests { get; init; }

    public int Page { get; init; }

    public int Length { get; init; }
}
