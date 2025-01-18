using ScientificWork.UseCases.Common.Dtos;

namespace ScientificWork.UseCases.Users.GetProfessorOnBoardingInfo;

public class GetProfessorOnBoardingInfoCommandResult
{
    public Guid Id { get; init; }

    public string? FirstName { get; init; }

    public string? LastName { get; init; }

    public string? Patronymic { get; init; }

    public string? PhoneNumber { get; init; }

    public string Email { get; init; } = null!;

    public string? Contacts { get; init; }

    public string? Degree { get; init; }

    public string? About { get; init; }

    public string? SearchStatus { get; set; }

    public int? Limit { get; init; }

    public List<ScientificAreasDto> ScientificArea { get; init; } = new List<ScientificAreasDto>();

    public IList<string> ScientificInterests { get; init; }

    public string? URPUri { get; init; }

    public string? ScopusUri { get; init; }

    public string? RISCUri { get; init; }
}