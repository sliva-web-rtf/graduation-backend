using Extensions.Hosting.AsyncInitialization;
using Microsoft.AspNetCore.Identity;
using ScientificWork.Domain.Admins;
using ScientificWork.Domain.Users;

namespace ScientificWork.Web.Infrastructure.Startup;

/// <summary>
/// Role init.
/// </summary>
public class RoleInitializer : IAsyncInitializer
{
    private readonly IServiceProvider serviceProvider;
    private readonly IConfiguration configuration;

    public RoleInitializer(IServiceProvider serviceProvider, IConfiguration configuration)
    {
        this.serviceProvider = serviceProvider;
        this.configuration = configuration;
    }

    public async Task InitializeAsync(CancellationToken cancellationToken)
    {
        var roleManager = serviceProvider.GetRequiredService<RoleManager<AppIdentityRole>>();
        var userManager = serviceProvider.GetRequiredService<UserManager<SystemAdmin>>();
        var roleNames = new[] { "admin", "student", "professor" };

        foreach (var roleName in roleNames)
        {
            var roleExist = await roleManager.RoleExistsAsync(roleName);
            if (!roleExist)
            {
                await roleManager.CreateAsync(new AppIdentityRole(roleName));
            }
        }

        var admin = SystemAdmin.Create(
            email: configuration["AdminOptions:Email"]!,
            firstName: "Admin",
            lastName: "Adminov");

        var isAdmin = await userManager.FindByEmailAsync(admin.Email!);

        if (isAdmin == null)
        {
            var createAdmin = await userManager.CreateAsync(admin, configuration["AdminOptions:Password"]!);
            if (createAdmin.Succeeded)
            {
                await userManager.AddToRoleAsync(admin, "admin");
            }
        }
    }
}
