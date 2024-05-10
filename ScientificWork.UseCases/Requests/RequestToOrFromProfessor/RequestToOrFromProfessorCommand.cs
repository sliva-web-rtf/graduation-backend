using MediatR;
using ScientificWork.Domain.Requests.Enums;

namespace ScientificWork.UseCases.Requests.RequestToOrFromProfessor;

public class RequestToOrFromProfessorCommand : IRequest
{
    /// <summary>
    /// Student id.
    /// </summary>
    required public Guid StudentId { get; init; }

    /// <summary>
    /// Professor id.
    /// </summary>
    required public Guid ProfessorId { get; init; }

    /// <summary>
    /// Scientific work id.
    /// </summary>
    required public Guid ScientificWorkId { get; init; }

    /// <summary>
    /// Request enum.
    /// </summary>
    required public RequestEnum RequestEnum { get; init; }
}
