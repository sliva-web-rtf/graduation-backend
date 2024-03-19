using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ScientificWork.Infrastructure.Abstractions.Interfaces;

namespace ScientificWork.UseCases.ScientificWorks.UpdateScientificWork;

public class UpdateScientificWorkCommandHandler : IRequestHandler<UpdateScientificWorkCommand>
{
    private readonly IAppDbContext dbContext;
    private readonly IMapper mapper;

    /// <summary>
    /// Constructor.
    /// </summary>
    public UpdateScientificWorkCommandHandler(IAppDbContext dbContext, IMapper mapper)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
    }

    /// <inheritdoc />
    public async Task Handle(UpdateScientificWorkCommand request, CancellationToken cancellationToken)
    {
        var scientificWork =
            await dbContext.ScientificWorks.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (scientificWork == null)
        {
            throw new Exception();
        }
        scientificWork.Update(request.Name, request.Title, request.Problem, request.Limit);

        await UpdateScientificInterestsAsync(scientificWork, request.ScientificInterests, cancellationToken);
        await UpdateScientificAreaSubsectionsAsync(scientificWork, request.ScientificAreaSubsections, cancellationToken);

        await dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task UpdateScientificAreaSubsectionsAsync(Domain.ScientificWorks.ScientificWork scientificWork, IList<string> scientificAreaSubsections,
        CancellationToken cancellationToken)
    {
        var selectedSubsections = await dbContext.ScientificAreaSubsections
            .Where(x => scientificAreaSubsections.Contains(x.Name))
            .ToArrayAsync(cancellationToken);

        scientificWork.UpdateScientificAreaSubsections(selectedSubsections);
    }

    private async Task UpdateScientificInterestsAsync(Domain.ScientificWorks.ScientificWork scientificWork, IList<string> scientificInterests,
        CancellationToken cancellationToken)
    {
        var selectedInterests = await dbContext.ScientificInterests
            .Where(x => scientificInterests.Contains(x.Name))
            .ToArrayAsync(cancellationToken);

        scientificWork.UpdateScientificInterest(selectedInterests);
    }
}
