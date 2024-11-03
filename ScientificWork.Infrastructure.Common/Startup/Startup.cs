using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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
using ScientificWork.Infrastructure.Common.Startup.Dependencies;
using ScientificWork.Infrastructure.DataAccess;
using ScientificWork.UseCases.Common.Settings.Authentication;
using ScientificWork.UseCases.Common.Settings.Email;
using ScientificWork.UseCases.Users.AuthenticateUser;


namespace ScientificWork.Infrastructure.Common.Startup;

public static class Startup
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        // We need to set the application name to data protection, since the default token
        // provider uses this data to create the token. If it is not specified explicitly,
        // tokens from different instances will be incompatible.
        services.AddDataProtection().SetApplicationName("Application")
            .PersistKeysToDbContext<AppDbContext>();

        services.AddEmailSender(configuration)
                .AddIdentity()
                .AddJwt(configuration)
                .AddScoped<ITokenModelService, TokenModelService>()
                .AddSingleton<IJsonHelper, SystemTextJsonHelper>()
                .AddScoped<IAuthenticationTokenService, SystemJwtTokenService>()
                .AddScoped<ILoggedUserAccessor, LoggedUserAccessor>();
        return services;
    }

    private static IServiceCollection AddEmailSender(this IServiceCollection services,
        IConfiguration configuration)
    {
        var emailSettings = new EmailSettings();
        configuration.Bind(EmailSettings.SectionName, emailSettings);
        services.AddSingleton(Options.Create(emailSettings));
        services.AddScoped<IEmailSender, EmailSender>();
        
        return services;
    }

    private static IServiceCollection AddIdentity(this IServiceCollection services)
    {
        services.AddScoped<RefreshTokenCreationOptions>();
        
        services.AddIdentity<User, AppIdentityRole>()
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders()
            .AddTokenProvider<RefreshTokenProvider<User>>(AuthenticationConstants.AppLoginProvider);
        services.Configure<IdentityOptions>(options =>
        {
            options.User.RequireUniqueEmail = true;
            options.Password.RequireNonAlphanumeric = false;
        });
        services.AddIdentityCore<Professor>().AddRoles<AppIdentityRole>().AddEntityFrameworkStores<AppDbContext>();
        services.AddIdentityCore<Student>().AddRoles<AppIdentityRole>().AddEntityFrameworkStores<AppDbContext>();
        services.AddIdentityCore<SystemAdmin>().AddRoles<AppIdentityRole>().AddEntityFrameworkStores<AppDbContext>();
        
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

        services.AddAuthorizationBuilder()
            .AddPolicy("RegistrationComplete", builder => { builder.RequireClaim("registrationComplete", "true"); })
            .AddPolicy("RegistrationNotComplete", builder => { builder.RequireClaim("registrationComplete", "false"); });

        return services;
    }
}