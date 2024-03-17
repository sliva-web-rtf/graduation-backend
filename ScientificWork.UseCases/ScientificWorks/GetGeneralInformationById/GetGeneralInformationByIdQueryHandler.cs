using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ScientificWork.Infrastructure.Abstractions.Interfaces;

namespace ScientificWork.UseCases.ScientificWorks.GetGeneralInformationById;

public class GetGeneralInformationByIdQueryHandler : IRequestHandler<GetGeneralInformationByIdQuery, GetGeneralInformationByIdResult>
{
    private readonly IMapper mapper;
    private readonly IAppDbContext dbContext;

    /// <summary>
    /// Constructor.
    /// </summary>
    public GetGeneralInformationByIdQueryHandler(IMapper mapper, IAppDbContext dbContext)
    {
        this.mapper = mapper;
        this.dbContext = dbContext;
    }

    /// <inheritdoc />
    public async Task<GetGeneralInformationByIdResult> Handle(GetGeneralInformationByIdQuery request,
        CancellationToken cancellationToken)
    {
        var scientificWorks = await dbContext.ScientificWorks
                .Where(x => x.Id == request.Id)
                .Include(x => x.ScientificInterests)
                .FirstOrDefaultAsync(cancellationToken);

        return mapper.Map<GetGeneralInformationByIdResult>(scientificWorks);
    }
}
