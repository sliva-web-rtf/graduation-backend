using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ScientificWork.Infrastructure.Abstractions.Interfaces;
using ScientificWork.UseCases.Common.Dtos;

namespace ScientificWork.UseCases.ScientificAreas.GetScientificAreas;

/// <summary>
/// Get scientific area name.
/// </summary>
public class GetScientificAreasQueryHandler : IRequestHandler<GetScientificAreasQuery, ICollection<ScientificAreasDto>>
{
    private readonly IAppDbContext dbContext;
    private readonly IMapper mapper;

    /// <summary>
    /// Constructor.
    /// </summary>
    public GetScientificAreasQueryHandler(IAppDbContext dbContext, IMapper mapper)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
    }

    /// <inheritdoc />
    public async Task<ICollection<ScientificAreasDto>> Handle(GetScientificAreasQuery request, CancellationToken cancellationToken)
    {
        var scientificAreas = await dbContext.ScientificAreas
            .Include(x => x.ScientificAreaSubsections)
            .Select(sa => mapper.Map<ScientificAreasDto>(sa))
            .ToListAsync(cancellationToken);

        return scientificAreas;
    }
}
