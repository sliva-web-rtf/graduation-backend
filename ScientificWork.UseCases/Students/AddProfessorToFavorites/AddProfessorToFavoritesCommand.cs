using System.ComponentModel.DataAnnotations;
using MediatR;

namespace ScientificWork.UseCases.Students.AddProfessorToFavorites;

public class AddProfessorToFavoritesCommand : IRequest
{
    /// <summary>
    /// Professor id.
    /// </summary>
    [Required]
    required public Guid ProfessorId { get; init; }
}
