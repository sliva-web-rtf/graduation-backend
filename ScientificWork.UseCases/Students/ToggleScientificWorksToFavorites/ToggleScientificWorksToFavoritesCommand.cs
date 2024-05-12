using System.ComponentModel.DataAnnotations;
using MediatR;
using ScientificWork.Domain.Favorites.Enums;

namespace ScientificWork.UseCases.Students.ToggleScientificWorksToFavorites;

public class ToggleScientificWorksToFavoritesCommand : IRequest
{
    /// <summary>
    /// Scientific works id.
    /// </summary>
    [Required]
    required public Guid ScientificWorksId { get; init; }

    /// <summary>
    /// Toggle enum.
    /// </summary>
    required public ToggleEnum ToggleEnum { get; init; }
}
