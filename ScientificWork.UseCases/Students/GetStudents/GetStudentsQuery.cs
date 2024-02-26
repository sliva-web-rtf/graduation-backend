using System.ComponentModel.DataAnnotations;
using MediatR;
using ScientificWork.UseCases.Students.Common.Dtos;

namespace ScientificWork.UseCases.Students.GetStudents;

/// <summary>
/// Get students query.
/// </summary>
public class GetStudentsQuery : IRequest<StudentDto>
{
    /// <summary>
    /// Page.
    /// </summary>
    [Required]
    required public int Page { get; init; } = 1;

    /// <summary>
    /// Page size.
    /// </summary>
    [Required]
    required public int PageSize { get; init; } = 20;

    /// <summary>
    /// Scientific area.
    /// </summary>
    public IList<string>? ScientificAreaSubsections { get; init; }

    /// <summary>
    /// Scientific interests.
    /// </summary>
    public IList<string>? ScientificInterests { get; init; }
}
