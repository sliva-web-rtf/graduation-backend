namespace ScientificWork.UseCases.Professors.Common.Dtos;

public class ProfessorDto
{
    public Guid Id { get; init; }

    public string? FirstName { get; init; }

    public string? LastName { get; init; }

    public string? Patronymic { get; init; }

    public string? Degree { get; init; }

    public string? Post { get; private set; }

    public string? About { get; init; }

    required public int Limit { get; init; }

    required public int Fullness { get; init; } = 1;

    public bool IsFavorite { get; set; }

    public bool CanJoin { get; set; }

    required public IList<string> ScientificInterests { get; init; }
}
