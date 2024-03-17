using System.ComponentModel.DataAnnotations;
using MediatR;
using Saritasa.Tools.Common.Pagination;
using ScientificWork.UseCases.Professors.Common.Dtos;

namespace ScientificWork.UseCases.Professors.GetProfessors;

public class GetProfessorsQuery : IRequest<PagedList<ProfessorDto>>
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
