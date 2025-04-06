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
        var stages = await dbContext.Stages.Select(s => s.Name).ToListAsync(cancellationToken);
        return new GetStagesQueryResult(stages);
    }
}