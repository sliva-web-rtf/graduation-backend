using Graduation.Application.Interfaces.Authentication;
using Graduation.Domain.Users;
using Graduation.Infrastructure.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Graduation.Infrastructure.Authentication;

public static class DependencyInjection
{
    public static IServiceCollection AddAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDataProtection().SetApplicationName("Graduation")
            .PersistKeysToDbContext<AppDbContext>();

        services
            .AddIdentity()
            .AddJwt(configuration)
            .AddSingleton<IJsonHelper, SystemTextJsonHelper>()
            .AddScoped<IAuthenticationTokenService, SystemJwtTokenService>()
            .AddScoped<IAuthenticationService, AuthenticationService>()
            .AddScoped<ILoggedUserAccessor, LoggedUserAccessor>();
        return services;
    }

    private static IServiceCollection AddIdentity(this IServiceCollection services)
    {
        services.Configure<IdentityOptions>(options =>
        {
            options.User.RequireUniqueEmail = false;
            options.User.AllowedUserNameCharacters = null;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireDigit = false;
            options.Tokens.EmailConfirmationTokenProvider = TokenOptions.DefaultEmailProvider;
        });

        services.AddIdentity<User, AppIdentityRole>()
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();

        services.AddScoped<IUserStore<User>, ApplicationUserStore>();

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
            .AddPolicy("RegistrationNotComplete",
                builder => { builder.RequireClaim("registrationComplete", "false"); });

        return services;
    }
}