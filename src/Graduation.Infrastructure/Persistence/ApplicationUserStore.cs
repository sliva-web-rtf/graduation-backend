using Graduation.Application.Interfaces.Services;
using Graduation.Domain.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Graduation.Infrastructure.Persistence;

public class ApplicationUserStore : UserStore<User, AppIdentityRole, AppDbContext, Guid, IdentityUserClaim<Guid>,
    ApplicationUserRole, IdentityUserLogin<Guid>, IdentityUserToken<Guid>, IdentityRoleClaim<Guid>>
{
    private readonly ICurrentYearProvider currentYearProvider;

    public ApplicationUserStore(AppDbContext context, 
        ICurrentYearProvider currentYearProvider,
        IdentityErrorDescriber? describer = null)
        : base(context, describer)
    {
        this.currentYearProvider = currentYearProvider;
    }

    protected override ApplicationUserRole CreateUserRole(User user, AppIdentityRole role)
    {
        return new ApplicationUserRole
        {
            UserId = user.Id,
            RoleId = role.Id,
            Year = currentYearProvider.GetCurrentYear()
        };
    }

    protected override Task<ApplicationUserRole?> FindUserRoleAsync(Guid userId, Guid roleId, CancellationToken cancellationToken)
    {
        var year = currentYearProvider.GetCurrentYear();
        return Context.Set<ApplicationUserRole>().FindAsync([userId, roleId, year], cancellationToken).AsTask();
    }
}