using AutoMapper;
using MediatR;
using ScientificWork.Infrastructure.Abstractions.Interfaces;

namespace ScientificWork.UseCases.ScientificWorks.GetRecordingSlotById;

public class GetRecordingSlotByIdQueryHandler : IRequestHandler<GetRecordingSlotByIdQuery, GetRecordingSlotByIdResult>
{
    private readonly IMapper mapper;
    private readonly IAppDbContext dbContext;

    /// <summary>
    /// Constructor.
    /// </summary>
    public GetRecordingSlotByIdQueryHandler(IMapper mapper, IAppDbContext dbContext)
    {
        this.mapper = mapper;
        this.dbContext = dbContext;
    }

    /// <inheritdoc />
    public Task<GetRecordingSlotByIdResult> Handle(GetRecordingSlotByIdQuery request, CancellationToken cancellationToken)
    {
        throw new Exception();
    }
}
