using System.ComponentModel.DataAnnotations;
using MediatR;

namespace ScientificWork.UseCases.Students.GetStudentProfileById;

/// <summary>
/// Get student profile by id query.
/// </summary>
public record GetStudentProfileByIdQuery : IRequest<GetStudentProfileByIdResult>
{
    /// <summary>
    /// Student id.
    /// </summary>
    [Required]
    required public Guid StudentId { get; init; }
}
