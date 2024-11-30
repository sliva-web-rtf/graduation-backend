using System.ComponentModel.DataAnnotations;
using ScientificWork.UseCases.Common.Dtos;

namespace ScientificWork.UseCases.Professors.GetProfessorScientificPortfolio;

public class GetProfessorScientificPortfolioQueryResult
{
    public Guid Id { get; init; }
    
    [Required]
    public string Degree { get; init; }

    public List<ScientificAreasDto> ScientificArea { get; } = new();

    public IList<string> ScientificInterests { get; init; }

    public string? URPUri { get; init; }

    public string? ScopusUri { get; init; }

    public string? RISCUri { get; init; }

    public string? About { get; init; }
}