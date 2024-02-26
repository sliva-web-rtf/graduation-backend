using System.ComponentModel.DataAnnotations;
using MediatR;
using ScientificWork.UseCases.Students.Common.Dtos;

namespace ScientificWork.UseCases.Students.GetStudentProfileById;

/// <summary>
/// Get student profile by id query.
/// </summary>
public record GetStudentProfileByIdQuery : IRequest<StudentDto>
{
    /// <summary>
    /// Student id.
    /// </summary>
    [Required]
    required public Guid StudentId { get; init; }
}
