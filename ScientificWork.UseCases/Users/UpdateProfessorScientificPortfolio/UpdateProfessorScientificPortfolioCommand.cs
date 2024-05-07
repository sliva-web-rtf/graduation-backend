using System.ComponentModel.DataAnnotations;
using MediatR;

namespace ScientificWork.UseCases.Users.UpdateProfessorScientificPortfolio;

public class UpdateProfessorScientificPortfolioCommand : IRequest
{
    [Required]
    public string Degree { get; init; }

    public IList<string>? ScientificAreaSubsections { get; init; }

    public IList<string>? ScientificInterests { get; init; }

}
