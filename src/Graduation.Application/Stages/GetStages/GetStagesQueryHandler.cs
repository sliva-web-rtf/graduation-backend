using Graduation.Application.Interfaces.DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Graduation.Application.Stages.GetStages;

public class GetStagesQueryHandler : IRequestHandler<GetStagesQuery, GetStagesQueryResult>
{
    private readonly IAppDbContext dbContext;

    public GetStagesQueryHandler(IAppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<GetStagesQueryResult> Handle(GetStagesQuery request, CancellationToken cancellationToken)
    {
        var stages = await dbContext.Stages
            .OrderBy(s => s.End)
            .ToListAsync(cancellationToken);

        var currentFound = false;
        var formattedStages = stages
            .Select(s =>
            {
                var isCurrent = DateOnly.FromDateTime(DateTime.UtcNow) <= s.End && !currentFound;
                if (isCurrent)
                    currentFound = true;
                return new GetStagesQueryResultStage(s.Name, s.Type, s.Begin, s.End, isCurrent);
            })
            .ToList();
        return new GetStagesQueryResult(formattedStages);
    }
}