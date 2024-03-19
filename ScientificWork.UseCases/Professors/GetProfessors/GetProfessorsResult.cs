using Saritasa.Tools.Common.Pagination;
using ScientificWork.UseCases.Professors.Common.Dtos;

namespace ScientificWork.UseCases.Professors.GetProfessors;

public record GetProfessorsResult
{
    public PagedList<ProfessorDto> Professors { get; init; }

    public int Page { get; init; }

    public int Length { get; init; }
}
