using System.ComponentModel.DataAnnotations;
using MediatR;

namespace ScientificWork.UseCases.ScientificInterests.GetScientificInterests;

public class GetScientificInterestsQuery : IRequest<IList<string>>
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
    /// Search.
    /// </summary>
    required public string Search { get; init; } = "";
}
