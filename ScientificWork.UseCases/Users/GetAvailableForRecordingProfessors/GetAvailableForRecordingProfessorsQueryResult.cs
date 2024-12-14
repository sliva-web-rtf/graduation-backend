using Saritasa.Tools.Common.Pagination;
using ScientificWork.UseCases.Professors.Common.Dtos;

namespace ScientificWork.UseCases.Users.GetAvailableForRecordingProfessors;

public record GetAvailableForRecordingProfessorsQueryResult
{
    public PagedList<ProfessorDto> Professors { get; init; }

    public int Page { get; init; }

    public int Length { get; init; }
}
