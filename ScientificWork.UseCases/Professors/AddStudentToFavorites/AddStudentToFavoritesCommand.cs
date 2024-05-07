using System.ComponentModel.DataAnnotations;
using MediatR;

namespace ScientificWork.UseCases.Professors.AddStudentToFavorites;

public class AddStudentToFavoritesCommand : IRequest
{
    /// <summary>
    /// Student id.
    /// </summary>
    [Required]
    required public Guid StudentId { get; init; }
}
