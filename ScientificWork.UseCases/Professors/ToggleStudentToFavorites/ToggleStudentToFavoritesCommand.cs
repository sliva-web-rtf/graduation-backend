using System.ComponentModel.DataAnnotations;
using MediatR;
using ScientificWork.Domain.Favorites.Enums;

namespace ScientificWork.UseCases.Professors.ToggleStudentToFavorites;

public class ToggleStudentToFavoritesCommand : IRequest
{
    /// <summary>
    /// Student id.
    /// </summary>
    [Required]
    required public Guid StudentId { get; init; }

    /// <summary>
    /// Toggle enum.
    /// </summary>
    required public ToggleEnum ToggleEnum { get; init; }
}
