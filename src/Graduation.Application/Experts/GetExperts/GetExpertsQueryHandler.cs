using Graduation.Application.Interfaces.DataAccess;
using Graduation.Domain;
using Graduation.Domain.Users;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Graduation.Application.Experts.GetExperts;

public class GetExpertsQueryHandler(IAppDbContext dbContext) : IRequestHandler<GetExpertsQuery, GetExpertsQueryResult>
{
    public async Task<GetExpertsQueryResult> Handle(GetExpertsQuery request, CancellationToken cancellationToken)
    {
        var usersCount = await GetExpertsQuery(request).CountAsync(cancellationToken);
        var pagesCount = (usersCount + request.PageSize - 1) / request.PageSize;

        var commissionExperts = await dbContext.CommissionExperts
            .Where(c => c.CommissionId == request.SortByCommissionId && c.Stage!.Name == request.Stage)
            .Select(c => c.UserId)
            .ToListAsync(cancellationToken);
        
        var experts = await GetExpertsQuery(request)
            .OrderByDescending(e => commissionExperts.Contains(e.Id))
            .ThenBy(e => e.LastName)
            .ThenBy(e => e.FirstName)
            .ThenBy(e => e.Patronymic)
            .Skip(request.Page * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync(cancellationToken);

        var formattedExperts = experts
            .Select(e => new GetExpertsQueryResultExpert(e.Id, e.FullName))
            .ToList();

        return new GetExpertsQueryResult(formattedExperts, pagesCount);
    }

    private IQueryable<User> GetExpertsQuery(GetExpertsQuery request)
    {
        var queryParts = (request.Query ?? "").Split(' ').Select(p => $"%{p}%").ToList();

        return dbContext.Users
            .Where(u => u.UserRoles.Any(ur => ur.Year == request.Year && ur.Role!.Name == WellKnownRoles.Expert))
            .Where(u => queryParts.All(p =>
                EF.Functions.ILike(u.FirstName!, p) ||
                EF.Functions.ILike(u.LastName!, p) ||
                EF.Functions.ILike(u.Patronymic!, p)
            ));
    }
}