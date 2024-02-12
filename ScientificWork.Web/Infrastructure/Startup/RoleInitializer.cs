using Microsoft.AspNetCore.Identity;
using ScientificWork.Domain.Users;

namespace ScientificWork.Web.Infrastructure.Startup;

/// <summary>
/// Role init.
/// </summary>
public static class RoleInitializer
{
    /// <summary>
    /// Creating roles at the first launch of the program.
    /// </summary>
    /// <param name="serviceProvider"></param>
    /// <param name="configuration"></param>
    public static async Task CreateRolesAsync(IServiceProvider serviceProvider, IConfiguration configuration)
    {
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = serviceProvider.GetRequiredService<UserManager<User>>();
        var roleNames = new[] { "admin", "student", "professor" };

        foreach (var roleName in roleNames)
        {
            var roleExist = await roleManager.RoleExistsAsync(roleName);
            if (!roleExist)
            {
                await roleManager.CreateAsync(new IdentityRole(roleName));
            }
        }

        var admin = new User
        {
            Email = configuration["AdminOptions:Email"],
            FirstName = "Admin",
            LastName = "Adminov"
        };

        var isAdmin = await userManager.FindByEmailAsync(admin.Email);

        if (isAdmin == null)
        {
            var createAdmin = await userManager.CreateAsync(admin, configuration["AdminOptions:Password"]);
            if (createAdmin.Succeeded)
            {
                await userManager.AddToRoleAsync(admin, "admin");
            }
        }
    }
}
