using MediatR;
using Microsoft.EntityFrameworkCore;
using ScientificWork.Infrastructure.Abstractions.Interfaces;

namespace ScientificWork.UseCases.ScientificInterests.GetScientificInterests;

public class GetScientificInterestsQueryHandler : IRequestHandler<GetScientificInterestsQuery, IList<string>>
{
    private readonly IAppDbContext dbContext;

    /// <summary>
    /// Constructor.
    /// </summary>
    public GetScientificInterestsQueryHandler(IAppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    /// <inheritdoc />
    public async Task<IList<string>> Handle(GetScientificInterestsQuery request, CancellationToken cancellationToken)
    {
        var scientificInterests =
            await dbContext.ScientificInterests
                .Where(x => x.Name.Contains(request.Search))
                .Select(x => x.Name)
                .ToListAsync(cancellationToken);

        return scientificInterests;
    }
}
