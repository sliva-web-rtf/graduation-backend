using Graduation.Application.Interfaces.Services;
using Graduation.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Graduation.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<ICurrentYearProvider, CurrentYearProvider>();
        services.AddScoped<IUserRoleAssignmentProcessorProvider, UserRoleAssignmentProcessorProvider>();
        services.AddScoped<StudentUserRoleAssignmentProcessor>();

        return services;
    }
}