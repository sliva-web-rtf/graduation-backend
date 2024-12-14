using Saritasa.Tools.Common.Pagination;
using ScientificWork.UseCases.Common.Dtos;

namespace ScientificWork.UseCases.Users.GetStudents;

public record GetStudentsQueryResult
{
    public PagedList<StudentDto> Students { get; init; }

    public int Page { get; init; }

    public int Length { get; init; }
}
