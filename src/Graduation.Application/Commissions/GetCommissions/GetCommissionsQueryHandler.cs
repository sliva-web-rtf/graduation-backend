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
            .Select(c =>
            {
                var secretaryName = $"{c.Secretary.LastName}";
                var firstNameChar = c.Secretary.FirstName?.FirstOrDefault();
                if (firstNameChar != null)
                    secretaryName += $" {firstNameChar}.";
                var patronymicChar = c.Secretary.Patronymic?.FirstOrDefault();
                if (patronymicChar != null)
                    secretaryName += $" {patronymicChar}.";
                return new GetCommissionsQueryResultCommission(c.Name, secretaryName);
            })
            .ToList();

        return new GetCommissionsQueryResult(formattedCommissions);
    }
}