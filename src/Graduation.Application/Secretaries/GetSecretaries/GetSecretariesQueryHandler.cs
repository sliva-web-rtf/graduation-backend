using Graduation.Application.Experts.GetExperts;
using Graduation.Application.Interfaces.DataAccess;
using Graduation.Domain;
using Graduation.Domain.Users;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Graduation.Application.Secretaries.GetSecretaries;

public class GetSecretariesQueryHandler(IAppDbContext dbContext) : IRequestHandler<GetSecretariesQuery, GetSecretariesQueryResult>
{
    public async Task<GetSecretariesQueryResult> Handle(GetSecretariesQuery request, CancellationToken cancellationToken)
    {
        var usersCount = await GetSecretariesQuery(request).CountAsync(cancellationToken);
        var pagesCount = (usersCount + request.PageSize - 1) / request.PageSize;

        var secretaries = await GetSecretariesQuery(request).Skip(request.Page * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync(cancellationToken);

        var formattedSecretaries = secretaries
            .Select(e => new GetSecretariesQueryResultSecretary(e.Id, e.FullName))
            .ToList();

        return new GetSecretariesQueryResult(formattedSecretaries, pagesCount);
    }

    private IQueryable<User> GetSecretariesQuery(GetSecretariesQuery request)
    {
        var queryParts = (request.Query ?? "").Split(' ').Select(p => $"%{p}%").ToList();

        return dbContext.Users
            .Where(u => u.UserRoles.Any(ur =>
                ur.Year == request.Year && (ur.Role!.Name == WellKnownRoles.Secretary ||
                                            ur.Role!.Name == WellKnownRoles.HeadSecretary)))
            .Where(u => queryParts.All(p =>
                EF.Functions.ILike(u.FirstName!, p) ||
                EF.Functions.ILike(u.LastName!, p) ||
                EF.Functions.ILike(u.Patronymic!, p)
            ));
    }
}