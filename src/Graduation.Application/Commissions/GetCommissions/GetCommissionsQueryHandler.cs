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
            .Include(c => c.Secretary)
            .Where(c => c.Year == request.Year)
            .ToListAsync(cancellationToken);

        var formattedCommissions = commissions
            .Select(c => new GetCommissionsQueryResultCommission(c.Id, c.Name, c.Secretary!.GetInitials()))
            .ToList();

        return new GetCommissionsQueryResult(formattedCommissions);
    }
}