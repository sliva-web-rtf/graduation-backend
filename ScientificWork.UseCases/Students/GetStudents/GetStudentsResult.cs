using ScientificWork.Infrastructure.Tools.Common.Pagination;
using ScientificWork.UseCases.Students.Common.Dtos;

namespace ScientificWork.UseCases.Students.GetStudents;

public record GetStudentsResult
{
    public PagedList<StudentDto> Students { get; init; }

    public int Page { get; init; }

    public int Length { get; init; }
}
