using Extensions.Hosting.AsyncInitialization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ScientificWork.Domain.Admins;
using ScientificWork.Domain.Professors;
using ScientificWork.Domain.Students;
using ScientificWork.Domain.Users;

namespace ScientificWork.Infrastructure.Presentation.Startup;

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
        var roleNames = new[] { nameof(SystemAdmin), nameof(Student), nameof(Professor) };

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
                await userManager.AddToRoleAsync(admin, nameof(SystemAdmin));
            }
        }
    }
}
