namespace ScientificWork.UseCases.Professors.Common.Dtos;

public class ProfessorDto
{
    public Guid Id { get; init; }

    public string? FirstName { get; init; }

    public string? LastName { get; init; }

    public string? Patronymic { get; init; }

    public string? Degree { get; init; }

    public string? Post { get; private set; }

    required public int Limit { get; init; }

    required public int Fullness { get; init; } = 1;

    required public IList<string> ScientificInterests { get; init; }
}
