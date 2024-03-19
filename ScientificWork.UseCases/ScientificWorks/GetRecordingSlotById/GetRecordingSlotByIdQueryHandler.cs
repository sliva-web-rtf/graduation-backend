using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ScientificWork.Infrastructure.Abstractions.Interfaces;
using ScientificWork.UseCases.Common.Exceptions;
using ScientificWork.UseCases.Students.Common.Dtos;

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
    public async Task<GetRecordingSlotByIdResult> Handle(GetRecordingSlotByIdQuery request, CancellationToken cancellationToken)
    {
        var scientificWork = await dbContext.ScientificWorks
            .Where(x => x.Id == request.Id)
            .Include(x => x.Students)
            .FirstOrDefaultAsync(cancellationToken);

        if (scientificWork == null)
        {
            throw new ScientificWorkNotFoundException($"Not found scientific work with id = {request.Id}");
        }

        var res = mapper.Map<GetRecordingSlotByIdResult>(scientificWork);
        res.StudentDtos = scientificWork.Students
            .Select(x => mapper.Map<StudentDto>(x))
            .ToList();

        return res;
    }
}
