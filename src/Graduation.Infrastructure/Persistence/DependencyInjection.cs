using Graduation.Application.Interfaces.DataAccess;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Graduation.Infrastructure.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext(configuration)
            .AddDataProtectionServices();
        
        return services;
    }
    
    private static IServiceCollection AddDataProtectionServices(this IServiceCollection services)
    {
        services.AddDataProtection().SetApplicationName("Graduation")
            .PersistKeysToDbContext<AppDbContext>();

        return services;
    }
    
    private static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        var databaseConnectionString = configuration.GetConnectionString("AppDatabase");
        if (string.IsNullOrWhiteSpace(databaseConnectionString))    
        {
            throw new ArgumentException("Database connection string is not initialized");
        }
        services.AddHealthChecks()
            .AddNpgSql(databaseConnectionString);
        
        services.AddDbContext<AppDbContext>(
            options =>
                options.UseNpgsql(
                    databaseConnectionString,
                    sqlOptions => sqlOptions.MigrationsAssembly(typeof(AppDbContext).Assembly.GetName().Name)
                ));
        
        services.AddScoped<IAppDbContext>(s => s.GetRequiredService<AppDbContext>());

        return services;
    }
}