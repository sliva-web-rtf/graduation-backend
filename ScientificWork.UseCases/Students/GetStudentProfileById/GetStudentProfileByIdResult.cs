using ScientificWork.UseCases.Common.Dtos;

namespace ScientificWork.UseCases.Students.GetStudentProfileById;

public record GetStudentProfileByIdResult
{
    public Guid Id { get; init; }

    public string? FirstName { get; init; }

    public string? LastName { get; init; }

    public string? Patronymic { get; init; }

    public string? PhoneNumber { get; init; }

    required public string Email { get; init; }

    public string? Contacts { get; init; }

    public string? Degree { get; init; }

    public string? About { get; init; }

    public int Year { get; init; }

    required public IList<ScientificAreasDto> ScientificArea { get; init; } = new List<ScientificAreasDto>();

    required public IList<string> ScientificInterests { get; init; }

    public string? URPUri { get; init; }

    public string? ScopusUri { get; init; }

    public string? RISCUri { get; init; }

    public string? Status { get; set; }

    public bool? CommandSearching { get; set; }

    public bool? ProfessorSearching { get; set; }

    public int? PublicationsCount { get; init; }

    public int? HIndex { get; init; }
}
