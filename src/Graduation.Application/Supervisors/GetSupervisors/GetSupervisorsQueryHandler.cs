using Graduation.Application.Interfaces.DataAccess;
using Graduation.Domain;
using Graduation.Domain.Users;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Graduation.Application.Supervisors.GetSupervisors;

public class GetSupervisorsQueryHandler : IRequestHandler<GetSupervisorsQuery, GetSupervisorsQueryResult>
{
    private readonly IAppDbContext dbContext;

    public GetSupervisorsQueryHandler(IAppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<GetSupervisorsQueryResult> Handle(GetSupervisorsQuery request,
        CancellationToken cancellationToken)
    {
        var usersCount = await GetSupervisorsQuery(request).CountAsync(cancellationToken);
        var pagesCount = (usersCount + request.PageSize - 1) / request.PageSize;

        var supervisors = await GetSupervisorsQuery(request)
            .Include(s => s.User)
            .ThenInclude(s => s!.UserRoleTopics.Where(urt => urt.Topic!.Year == request.Year))
            .Skip(request.Page * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync(cancellationToken);

        var formattedSupervisors = supervisors.Select(s => new GetSupervisorsQuerySupervisor(
                s.UserId,
                s.User!.FullName,
                s.User.About,
                s.Limit,
                s.User.UserRoleTopics.Count
            ))
            .ToList();

        return new GetSupervisorsQueryResult(formattedSupervisors, pagesCount);
    }

    private IQueryable<SupervisorLimit> GetSupervisorsQuery(GetSupervisorsQuery request)
    {
        var queryParts = (request.Query ?? "").Split(' ').Select(p => $"%{p}%").ToList();

        return dbContext.SupervisorLimits
            .Where(s => s.User!.UserRoles.Any(ur => ur.Year == request.Year &&
                                                    ur.Role!.Name == WellKnownRoles.Supervisor))
            .Where(s => queryParts.All(p =>
                s.User!.FirstName == null || EF.Functions.ILike(s.User.FirstName, p) ||
                s.User.LastName == null || EF.Functions.ILike(s.User.LastName, p) ||
                s.User.Patronymic == null || EF.Functions.ILike(s.User.Patronymic, p)));
    }
}