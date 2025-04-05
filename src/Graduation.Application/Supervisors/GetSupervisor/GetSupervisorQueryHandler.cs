using Graduation.Application.Interfaces.DataAccess;
using Graduation.Domain;
using Graduation.Domain.Exceptions;
using Graduation.Domain.Users;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Graduation.Application.Supervisors.GetSupervisor;

public class GetSupervisorQueryHandler : IRequestHandler<GetSupervisorQuery, GetSupervisorQueryResult>
{
    private readonly IAppDbContext dbContext;
    private readonly UserManager<User> userManager;

    public GetSupervisorQueryHandler(IAppDbContext dbContext, UserManager<User> userManager)
    {
        this.dbContext = dbContext;
        this.userManager = userManager;
    }

    public async Task<GetSupervisorQueryResult> Handle(GetSupervisorQuery request, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByIdAsync(request.Id.ToString())
                   ?? throw new DomainException("User not found");
        if (!await userManager.IsInRoleAsync(user, WellKnownRoles.Supervisor))
            throw new DomainException("User is not supervisor");

        var supervisor = await dbContext.SupervisorLimits
            .Where(s => s.UserId == request.Id)
            .Include(s => s.User)
            .ThenInclude(s => s!.UserRoleTopics.Where(urt => urt.Topic!.Year == request.Year))
            .FirstAsync(cancellationToken);

        var result = new GetSupervisorQueryResult(
            supervisor.User!.FullName,
            supervisor.User.Contacts,
            supervisor.User.About,
            supervisor.Limit,
            supervisor.User.UserRoleTopics.Count
        );

        return result;
    }
}