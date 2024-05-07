using System.ComponentModel.DataAnnotations;
using MediatR;

namespace ScientificWork.UseCases.Users.UpdateProfessorScientificPortfolio;

public class UpdateProfessorScientificPortfolioCommand : IRequest
{
    [Required]
    public string Degree { get; init; }

    public string? Address { get; init; }

    public string? About { get; init; }

    public string? Post { get; init; }

    public int Limit { get; init; }

    public int WorkExperienceYears { get; init; }

    public string? ScopusUri { get; init; }

    public string? RISCUri { get; init; }

    public string? URPUri { get; init; }

    public IList<string>? ScientificAreaSubsections { get; init; }

    public IList<string>? ScientificInterests { get; init; }
}
