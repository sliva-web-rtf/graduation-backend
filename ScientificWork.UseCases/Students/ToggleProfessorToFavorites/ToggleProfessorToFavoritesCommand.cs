using System.ComponentModel.DataAnnotations;
using MediatR;
using ScientificWork.Domain.Favorites.Enums;

namespace ScientificWork.UseCases.Students.ToggleProfessorToFavorites;

public class ToggleProfessorToFavoritesCommand : IRequest
{
    /// <summary>
    /// Professor id.
    /// </summary>
    [Required]
    required public Guid ProfessorId { get; init; }

    /// <summary>
    /// Toggle enum.
    /// </summary>
    required public ToggleEnum ToggleEnum { get; init; }
}
