using System.ComponentModel.DataAnnotations;
using MediatR;

namespace ScientificWork.UseCases.Professors.GetProfileById;

public class GetProfileQuery : IRequest<GetProfileByIdResult>
{
    /// <summary>
    /// Professors id.
    /// </summary>
    [Required]
    required public Guid ProfessorId { get; init; }
}
