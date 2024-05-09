using System.ComponentModel.DataAnnotations;
using MediatR;

namespace ScientificWork.UseCases.Students.AddStudentToFavorites;

public class AddStudentToFavoritesCommand : IRequest
{
    /// <summary>
    /// Student id.
    /// </summary>
    [Required]
    required public Guid StudentId { get; init; }
}
