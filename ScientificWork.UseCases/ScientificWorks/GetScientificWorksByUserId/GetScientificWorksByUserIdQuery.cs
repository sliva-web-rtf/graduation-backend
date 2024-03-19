using MediatR;
using ScientificWork.UseCases.ScientificWorks.Common.Dtos;

namespace ScientificWork.UseCases.ScientificWorks.GetScientificWorksByUserId;

public class GetScientificWorksByUserIdQuery : IRequest<List<ScientificWorkDto>>
{
    /// <summary>
    /// User id.
    /// </summary>
    required public Guid UserId { get; init; }
}
