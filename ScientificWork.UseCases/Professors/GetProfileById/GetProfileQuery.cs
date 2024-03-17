using System.ComponentModel.DataAnnotations;
using MediatR;
using ScientificWork.UseCases.Professors.Common.Dtos;

namespace ScientificWork.UseCases.Professors.GetProfileById;

public class GetProfileQuery : IRequest<ProfessorDto>
{
    /// <summary>
    /// Professors id.
    /// </summary>
    [Required]
    required public Guid ProfessorId { get; init; }
}
