using System.ComponentModel.DataAnnotations;
using MediatR;

namespace ScientificWork.UseCases.Professors.AddScientificWorksToFavorites;

public class AddScientificWorksToFavoritesCommand : IRequest
{
    /// <summary>
    /// Scientific works id.
    /// </summary>
    [Required]
    required public Guid ScientificWorksId { get; init; }
}
