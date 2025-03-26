using Microsoft.AspNetCore.Identity;

namespace Graduation.Domain.Users;

public class AppIdentityRole : IdentityRole<Guid>
{
    public AppIdentityRole(string name)
        : base(name)
    {
    }
}
