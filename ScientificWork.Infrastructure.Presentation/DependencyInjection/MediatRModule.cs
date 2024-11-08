using Microsoft.Extensions.DependencyInjection;
using ScientificWork.UseCases.Users.AuthenticateUser.LoginUser;

namespace ScientificWork.Infrastructure.Presentation.DependencyInjection;

/// <summary>
/// Register Mediator as dependency.
/// </summary>
public static class MediatRModule
{
    /// <summary>
    /// Register dependencies.
    /// </summary>
    /// <param name="services">Services.</param>
    public static void Register(IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(LoginUserCommand).Assembly));
    }
}
