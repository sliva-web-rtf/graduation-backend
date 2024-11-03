using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.DependencyInjection;
using ScientificWork.Infrastructure.Abstractions.Interfaces;
using ScientificWork.Infrastructure.DataAccess;
using ScientificWork.UseCases.Users.AuthenticateUser;
using ScientificWork.Web.Infrastructure.Jwt;
using ScientificWork.Web.Infrastructure.Web;

namespace ScientificWork.Infrastructure.Presentation.DependencyInjection;

/// <summary>
/// System specific dependencies.
/// </summary>
public static class SystemModule
{
    /// <summary>
    /// Register dependencies.
    /// </summary>
    /// <param name="services">Services.</param>
    public static void Register(IServiceCollection services)
    {
        services.AddSingleton<IJsonHelper, SystemTextJsonHelper>();
        services.AddScoped<IAuthenticationTokenService, SystemJwtTokenService>();
        services.AddScoped<IAppDbContext>(s => s.GetRequiredService<AppDbContext>());
        services.AddScoped<ILoggedUserAccessor, LoggedUserAccessor>();
    }
}
