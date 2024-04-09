using System.ComponentModel.DataAnnotations;
using MediatR;

namespace ScientificWork.UseCases.Users.UpdateStudentScientificPortfolio;

public class UpdateStudentScientificPortfolioCommand : IRequest
{
    [Required]
    public string Degree { get; init; }

    public IList<string>? ScientificAreaSubsections { get; init; }

    public IList<string>? ScientificInterests { get; init; }

    public string? About { get; init; }
}
