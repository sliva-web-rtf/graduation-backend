using System.ComponentModel.DataAnnotations;
using MediatR;

namespace ScientificWork.UseCases.Requests.GetProfessorRequestsStudent;

public class GetProfessorRequestsStudentQuery : IRequest<GetProfessorRequestsStudentResult>
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
}
