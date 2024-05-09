using System.ComponentModel.DataAnnotations;
using MediatR;

namespace ScientificWork.UseCases.Students.AddScientificWorksToFavorites;

public class AddScientificWorksToFavoritesCommand : IRequest
{
    /// <summary>
    /// Scientific works id.
    /// </summary>
    [Required]
    required public Guid ScientificWorksId { get; init; }
}
