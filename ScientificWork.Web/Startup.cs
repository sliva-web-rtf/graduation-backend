using System.Net;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using ScientificWork.Domain.Admins;
using ScientificWork.Domain.Professors;
using ScientificWork.Domain.Students;
using ScientificWork.Domain.Users;
using ScientificWork.Infrastructure.Abstractions.Interfaces;
using ScientificWork.Infrastructure.Abstractions.Interfaces.Authentication;
using ScientificWork.Infrastructure.Abstractions.Interfaces.Email;
using ScientificWork.Infrastructure.Common.Authentication;
using ScientificWork.Infrastructure.Common.Services.Email;
using ScientificWork.Infrastructure.DataAccess;
using ScientificWork.UseCases.Common.Settings.Authentication;
using ScientificWork.UseCases.Common.Settings.Email;
using ScientificWork.UseCases.Users;
using ScientificWork.UseCases.Users.AuthenticateUser;
using ScientificWork.UseCases.Users.AuthenticateUser.LoginUser;
using ScientificWork.Web.Infrastructure.Authentication;
using ScientificWork.Web.Infrastructure.Jwt;
using ScientificWork.Web.Infrastructure.Middlewares;
using ScientificWork.Web.Infrastructure.Settings;
using ScientificWork.Web.Infrastructure.Startup;
using ScientificWork.Web.Infrastructure.Startup.HealthCheck;
using ScientificWork.Web.Infrastructure.Startup.Swagger;
using ScientificWork.Web.Infrastructure.Web;

namespace ScientificWork.Web;

/// <summary>
/// Entry point for ASP.NET Core app.
/// </summary>
public static class DependencyInjection
{

    /// <summary>
    /// Configure application services on startup.
    /// </summary>
    /// <param name="services">Services to configure.</param>
    /// <param name="environment">Application environment.</param>
    /// <param name="configuration">Aplication configuration</param>
    public static IServiceCollection AddApplication(this IServiceCollection services, IWebHostEnvironment environment, IConfiguration configuration)
    {
        services.AddSwaggerGen(new SwaggerGenOptionsSetup().Setup) // Swagger
                .AddCORS(environment, configuration) // CORS
                .AddXForward(configuration) // x-forward
                .AddAplicationMVC() // MVC
                .AddAplicationDataProtection(configuration) // We need to set the application name to data protection, since the default token
                                                            // provider uses this data to create the token. If it is not specified explicitly,
                                                            // tokens from different instances will be incompatible.
                .AddAplicationIdentity() // Identity.
                .AddJwt(configuration) // JWT
                .AddHealthCheckAndDB(configuration) // Health check
                                                    // Database
                .AddLogging(new LoggingOptionsSetup(configuration, environment).Setup) // Logging.
                .Configure<AppSettings>(configuration.GetSection("Application")) // Application settings.
                .AddHttpClient() // HTTP client.
                .AddScoped<ITokenModelService, TokenModelService>() // Application 
                .AddAutoMapper(typeof(UserMappingProfile).Assembly) // AutoMapper
                .AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(LoginUserCommand).Assembly)) // MediatR
                .AddSystem();
        return services;
    }

    /// <summary>
    /// Configure web application.
    /// </summary>
    /// <param name="app">Application builder.</param>
    public static IApplicationBuilder UseApplication(this IApplicationBuilder app)
    {
        app.UseStaticFiles()
            .UseSwagger() // Swagger
            .UseSwaggerUI(new SwaggerUIOptionsSetup().Setup)
            .UseMiddleware<ApiExceptionMiddleware>() // Custom middlewares.
            .UseRouting() // MVC
            .UseCors(CorsOptionsSetup.CorsPolicyName) // CORS.
            .UseForwardedHeaders(new ForwardedHeadersOptions { ForwardedHeaders = ForwardedHeaders.All })
            .UseAuthentication()
            .UseAuthorization()
            .UseEndpoints(endpoints =>
            {
                HealthCheckModule.Register(endpoints);
                endpoints.Map("/", context =>
                {
                    context.Response.Redirect("/swagger");
                    return Task.CompletedTask;
                });
                endpoints.MapControllers();
            });

        return app;
    }

    private static IServiceCollection AddSystem(this IServiceCollection services)
    {
        services.AddSingleton<IJsonHelper, SystemTextJsonHelper>()
                .AddScoped<IAuthenticationTokenService, SystemJwtTokenService>()
                .AddScoped<IAppDbContext>(s => s.GetRequiredService<AppDbContext>())
                .AddScoped<ILoggedUserAccessor, LoggedUserAccessor>();

        return services;
    }

    private static IServiceCollection AddHealthCheckAndDB(this IServiceCollection services, IConfiguration configuration)
    {
        //Health Check
        var databaseConnectionString = configuration.GetConnectionString("AppDatabase")
                                       ?? throw new ArgumentException("Database connection string is not initialized");
        services.AddHealthChecks()
            .AddNpgSql(databaseConnectionString);
        // Database.
        services.AddDbContext<AppDbContext>(
            new DbContextOptionsSetup(databaseConnectionString).Setup);
        services.AddAsyncInitializer<DatabaseInitializer>()
            .AddAsyncInitializer<RoleInitializer>();

        return services;
    }

    private static IServiceCollection AddJwt(this IServiceCollection services, IConfiguration configuration)
    {
        var jwtSecretKey = configuration["Jwt:SecretKey"] ?? throw new ArgumentException("Jwt:SecretKey");
        var jwtIssuer = configuration["Jwt:Issuer"] ?? throw new ArgumentException("Jwt:Issuer");
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
            .AddJwtBearer(new JwtBearerOptionsSetup(
                jwtSecretKey,
                jwtIssuer).Setup
            );

        services.AddAuthorization(options =>
        {
            options.AddPolicy("RegistrationComplete",
                builder => { builder.RequireClaim("registrationComplete", "true"); });
            options.AddPolicy("RegistrationNotComplete",
                builder => { builder.RequireClaim("registrationComplete", "false"); });
        });

        return services;
    }

    private static IServiceCollection AddAplicationIdentity(this IServiceCollection services)
    {
        services.AddIdentity<User, AppIdentityRole>()
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders()
            .AddTokenProvider<RefreshTokenProvider<User>>(AuthenticationConstants.AppLoginProvider);
        services.Configure<IdentityOptions>(new IdentityOptionsSetup().Setup);
        services.AddIdentityCore<Professor>().AddRoles<AppIdentityRole>().AddEntityFrameworkStores<AppDbContext>();
        services.AddIdentityCore<Student>().AddRoles<AppIdentityRole>().AddEntityFrameworkStores<AppDbContext>();
        services.AddIdentityCore<SystemAdmin>().AddRoles<AppIdentityRole>().AddEntityFrameworkStores<AppDbContext>();

        return services;
    }

    private static IServiceCollection AddAplicationDataProtection(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDataProtection().SetApplicationName("Application")
            .PersistKeysToDbContext<AppDbContext>();

        var emailSettings = new EmailSettings();
        configuration.Bind(EmailSettings.SectionName, emailSettings);
        services.AddSingleton(Options.Create(emailSettings));
        services.AddScoped<IEmailSender, EmailSender>();

        services.AddScoped<RefreshTokenCreationOptions>();
        return services;
    }

    private static IServiceCollection AddAplicationMVC(this IServiceCollection services)
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

    private static IServiceCollection AddCORS(this IServiceCollection services, IWebHostEnvironment environment, IConfiguration configuration)
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