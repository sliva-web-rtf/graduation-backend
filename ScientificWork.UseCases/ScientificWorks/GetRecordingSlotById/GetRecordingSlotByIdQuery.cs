using MediatR;

namespace ScientificWork.UseCases.ScientificWorks.GetRecordingSlotById;

public class GetRecordingSlotByIdQuery : IRequest<GetRecordingSlotByIdResult>
{
    /// <summary>
    /// Scientific work id.
    /// </summary>
    required public Guid Id { get; init; }
}
