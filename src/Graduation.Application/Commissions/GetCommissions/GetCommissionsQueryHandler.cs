using Graduation.Application.Interfaces.DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Graduation.Application.Commissions.GetCommissions;

public class GetCommissionsQueryHandler : IRequestHandler<GetCommissionsQuery, GetCommissionsQueryResult>
{
    private readonly IAppDbContext dbContext;

    public GetCommissionsQueryHandler(IAppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<GetCommissionsQueryResult> Handle(GetCommissionsQuery request,
        CancellationToken cancellationToken)
    {
        var commissions = await dbContext.Commissions
            .Where(c => c.Year == request.Year)
            .ToListAsync();

        var formattedCommissions = commissions
            .Select(c => new GetCommissionsQueryResultCommission(c.Name))
            .ToList();

        return new GetCommissionsQueryResult(formattedCommissions);
    }
}