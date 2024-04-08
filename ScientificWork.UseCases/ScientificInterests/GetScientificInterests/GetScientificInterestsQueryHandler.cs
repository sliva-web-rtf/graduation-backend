using MediatR;
using Saritasa.Tools.Common.Pagination;
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
        var scientificInterests = dbContext.ScientificInterests
                .Where(x => x.Name.ToLower().StartsWith(request.Search.ToLower()))
                .Select(x => x.Name);

        return PagedListFactory.FromSource(scientificInterests, page: request.Page, pageSize: request.PageSize).ToList();
    }
}
