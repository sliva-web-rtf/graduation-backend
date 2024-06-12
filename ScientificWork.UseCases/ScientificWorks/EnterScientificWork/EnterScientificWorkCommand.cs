using MediatR;

namespace ScientificWork.UseCases.ScientificWorks.EnterScientificWork;

public class EnterScientificWorkCommand : IRequest
{
    public Guid ScientificWorkId { get; init; }
}