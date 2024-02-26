using ScientificWork.UseCases.Common.Dtos;

namespace ScientificWork.UseCases.Students.Common.Dtos;

public class StudentDto
{
    required public string FirstName { get; init; }

    required public string LastName { get; init; }

    public string? Patronymic { get; init; }

    public string? PhoneNumber { get; init; }

    required public string Email { get; init; }

    public string? Сontacts { get; init; }

    required public string Degree { get; init; }

    required public IList<ScientificAreasDto> ScientificArea { get; init; }

    required public IList<string> ScientificInterests { get; init; }

    public string? URPUri { get; init; }

    public string? ScopusUri { get; init; }

    public string? RISCUri { get; init; }

    public int? PublicationsCount { get; init; }

    public int? HIndex { get; init; }
}
