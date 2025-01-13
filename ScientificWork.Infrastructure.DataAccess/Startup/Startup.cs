using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ScientificWork.Infrastructure.Abstractions.Interfaces;
using ScientificWork.Infrastructure.DataAccess.Startup.Dependencies;

namespace ScientificWork.Infrastructure.DataAccess.Startup;

public static class Startup
{
    public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration)
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
        services.AddAsyncInitializer<DatabaseInitializer>();
        
        services.AddScoped<IAppDbContext>(s => s.GetRequiredService<AppDbContext>());
        return services;
    }
}