using System.ComponentModel.DataAnnotations;
using ScientificWork.UseCases.Common.Dtos;

namespace ScientificWork.UseCases.Students.GetStudentScientificPortfolio;

public class GetStudentScientificPortfolioQueryResult
{
    public Guid Id { get; init; }
    
    [Required] 
    public string? Degree { get; init; }
    
    public int Year { get; init; }

    public List<ScientificAreasDto>? ScientificArea { get; } = new();

    public IList<string>? ScientificInterests { get; init; }
    
    public string? About { get; init; }
}