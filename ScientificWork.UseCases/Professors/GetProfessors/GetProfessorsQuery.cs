using System.ComponentModel.DataAnnotations;
using MediatR;

namespace ScientificWork.UseCases.Professors.GetProfessors;

public class GetProfessorsQuery : IRequest<GetProfessorsResult>
{
    /// <summary>
    /// Page.
    /// </summary>
    [Required]
    required public int Page { get; init; } = 1;

    /// <summary>
    /// Page size.
    /// </summary>
    [Required]
    required public int PageSize { get; init; } = 20;

    /// <summary>
    /// Scientific area.
    /// </summary>
    public IList<string>? ScientificAreaSubsections { get; init; }

    /// <summary>
    /// Scientific interests.
    /// </summary>
    public IList<string>? ScientificInterests { get; init; }

    /// <summary>
    /// Filter by favorite.
    /// </summary>
    public bool IsFavoriteFilter { get; init; }

    /// <summary>
    /// Get only favorite.
    /// </summary>
    public bool IsFavoriteFilterOnly { get; init; }
}
