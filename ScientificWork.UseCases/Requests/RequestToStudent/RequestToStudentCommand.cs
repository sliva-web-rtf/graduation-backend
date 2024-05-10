using MediatR;
using ScientificWork.Domain.Requests.Enums;

namespace ScientificWork.UseCases.Requests.RequestToStudent;

public class RequestToStudentCommand : IRequest
{
    /// <summary>
    /// Student From id.
    /// </summary>
    required public Guid StudentFromId { get; init; }

    /// <summary>
    /// Student To  id.
    /// </summary>
    required public Guid StudentToId { get; init; }

    /// <summary>
    /// Scientific work id.
    /// </summary>
    required public Guid ScientificWorkId { get; init; }

    /// <summary>
    /// Request enum.
    /// </summary>
    required public RequestEnum RequestEnum { get; init; }
}
