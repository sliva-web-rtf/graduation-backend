using System.Net;
using Microsoft.AspNetCore.Mvc;
using ScientificWork.Web.Infrastructure.Settings;
using ScientificWork.Web.Infrastructure.Startup;
using ScientificWork.Web.Infrastructure.Startup.Swagger;

namespace ScientificWork.Web;

public static class Startup
{
    public static IServiceCollection AddApi(this IServiceCollection services,
        IWebHostEnvironment environment,
        IConfiguration configuration)
    {
        services.AddSwaggerGen(new SwaggerGenOptionsSetup().Setup)
            .AddApplicationCors(environment, configuration) // CORS
            .AddXForward(configuration) // x-forward
            .AddApplicationMvc() // MVC
            .AddLogging(new LoggingOptionsSetup(configuration, environment).Setup) // Logging.
            .Configure<AppSettings>(configuration.GetSection("Application")) // Application settings.
            .AddHttpClient(); // HTTP client.
        return services;
    }

    private static IServiceCollection AddApplicationMvc(this IServiceCollection services)
    {
        services.AddControllers()
            .AddJsonOptions(new JsonOptionsSetup().Setup);
        services.Configure<ApiBehaviorOptions>(new ApiBehaviorOptionsSetup().Setup);
        
        return services;
    }

    private static IServiceCollection AddXForward(this IServiceCollection services, IConfiguration configuration)
    {
        var knownProxies = (configuration["KnownProxies"] ?? string.Empty)
            .Split(';', StringSplitOptions.RemoveEmptyEntries);
        services.Configure<ForwardedHeadersOptions>(options =>
        {
            foreach (var proxy in knownProxies)
            {
                options.KnownProxies.Add(IPAddress.Parse(proxy));
            }
        });
        
        return services;
    }

    private static IServiceCollection AddApplicationCors(this IServiceCollection services,
        IWebHostEnvironment environment, IConfiguration configuration)
    {
        var frontendOrigin = (configuration["FrontendOrigin"] ?? string.Empty)
            .Split(';', StringSplitOptions.RemoveEmptyEntries);
        services.AddCors(new CorsOptionsSetup(
            environment.IsDevelopment(),
            frontendOrigin
        ).Setup);
        
        return services;
    }
}
