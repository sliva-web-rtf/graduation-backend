using MediatR;

namespace ScientificWork.UseCases.ScientificWorks.LeaveScientificWork;

public class LeaveScientificWorkCommand : IRequest
{
    public Guid ScientificWorkId { get; init; }
}