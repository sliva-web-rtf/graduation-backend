namespace ScientificWork.UseCases.Students.Common.Dtos;

public class StudentDto
{
    public Guid Id { get; init; }

    public string? FirstName { get; init; }

    public string? LastName { get; init; }

    public string? Patronymic { get; init; }

    public string? Degree { get; init; }

    public string? About { get; init; }

    required public IList<string> ScientificInterests { get; init; }

    public string? Status { get; set; }

    public bool IsFavorite { get; set; }

    public bool? CommandSearching { get; set; }

    public bool? ProfessorSearching { get; set; }
}
