using Graduation.Application.Interfaces.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;

namespace Graduation.Infrastructure.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext(configuration);

        return services;
    }

    private static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        var databaseConnectionString = configuration.GetConnectionString("AppDatabase");
        if (string.IsNullOrWhiteSpace(databaseConnectionString))
            throw new ArgumentException("Database connection string is not initialized");
        services.AddHealthChecks()
            .AddNpgSql(databaseConnectionString);

        var dataSourceBuilder = new NpgsqlDataSourceBuilder(databaseConnectionString);
        dataSourceBuilder.EnableDynamicJson();

        var dataSource = dataSourceBuilder.Build();

        services.AddDbContext<AppDbContext>(
            options =>
                options.UseNpgsql(
                    dataSource,
                    sqlOptions => sqlOptions.MigrationsAssembly(typeof(AppDbContext).Assembly.GetName().Name)
                ));

        services.AddScoped<IAppDbContext>(s => s.GetRequiredService<AppDbContext>());

        return services;
    }
}