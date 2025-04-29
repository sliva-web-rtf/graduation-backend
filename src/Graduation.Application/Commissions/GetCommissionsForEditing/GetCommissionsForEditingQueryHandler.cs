using Graduation.Application.Interfaces.DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Graduation.Application.Commissions.GetCommissionsForEditing;

public class GetCommissionsForEditingQueryHandler(IAppDbContext dbContext)
    : IRequestHandler<GetCommissionsForEditingQuery, GetCommissionsForEditingQueryResult>
{
    public async Task<GetCommissionsForEditingQueryResult> Handle(GetCommissionsForEditingQuery request,
        CancellationToken cancellationToken)
    {
        var commissions = await dbContext.Commissions
            .Include(c => c.Secretary)
            .Include(c => c.Chairperson)
            .Where(c => c.Year == request.Year)
            .ToListAsync(cancellationToken);

        var formattedCommissions = commissions
            .Select(c =>
                new GetCommissionsForEditingQueryResultCommission(
                    c.Id,
                    c.Name,
                    c.Secretary!.FullName,
                    c.Chairperson?.FullName))
            .ToList();

        return new GetCommissionsForEditingQueryResult(formattedCommissions);
    }
}