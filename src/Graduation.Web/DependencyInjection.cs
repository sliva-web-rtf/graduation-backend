using System.Net;
using Graduation.Web.Settings;
using Graduation.Web.Startup;
using Graduation.Web.Startup.Swagger;
using Microsoft.AspNetCore.Mvc;

namespace Graduation.Web;

public static class DependencyInjection
{
    public static IServiceCollection AddApi(this IServiceCollection services,
        IWebHostEnvironment environment,
        IConfiguration configuration)
    {
        services.AddSwaggerGen(options => SwaggerGenOptionsSetup.Setup(options, typeof(Program).Assembly))
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