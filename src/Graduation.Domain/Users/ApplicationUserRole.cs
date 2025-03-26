using Microsoft.AspNetCore.Identity;

namespace Graduation.Domain.Users;

public class ApplicationUserRole : IdentityUserRole<Guid>
{
    public string Year { get; set; }
}