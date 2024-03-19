using ScientificWork.UseCases.Common.Dtos;

namespace ScientificWork.UseCases.Professors.GetProfileById;

public record GetProfileByIdResult
{
    public Guid Id { get; init; }

    public string? FirstName { get; init; }

    public string? LastName { get; init; }

    public string? Patronymic { get; init; }

    public string? PhoneNumber { get; init; }

    required public string Email { get; init; }

    public string? Contacts { get; init; }

    public string? Degree { get; init; }

    public string? Address { get; private set; }

    public string? Post { get; private set; }

    required public int Limit { get; init; }

    required public int Fullness { get; init; } = 1;

    required public IList<ScientificAreasDto> ScientificArea { get; init; } = new List<ScientificAreasDto>();

    required public IList<string> ScientificInterests { get; init; }

    public string? URPUri { get; init; }

    public string? ScopusUri { get; init; }

    public string? RISCUri { get; init; }

    public int PublicationsCount { get; init; }

    public int? HIndex { get; init; }
}
