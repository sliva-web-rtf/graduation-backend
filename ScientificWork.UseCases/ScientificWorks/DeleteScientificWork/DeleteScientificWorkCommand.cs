using MediatR;

namespace ScientificWork.UseCases.ScientificWorks.DeleteScientificWork;

public class DeleteScientificWorkCommand : IRequest
{
    /// <summary>
    /// Scientific work id.
    /// </summary>
    required public Guid Id { get; init; }
}
