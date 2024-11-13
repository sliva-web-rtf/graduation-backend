using Microsoft.Extensions.DependencyInjection;
using ScientificWork.UseCases.Users.AuthenticateUser.LoginUser;
using ScientificWork.UseCases.Users;

namespace ScientificWork.UseCases;

public static class Startup
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        services
            .AddAutoMapper(typeof(UserMappingProfile).Assembly) // AutoMapper
            .AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(LoginUserCommand).Assembly)); // MediatR
        return services;
    }
}

// TODO:
// Для метода AddAutoMapper добавил в проект AutoMapper.Extensions.Microsoft.DependencyInjection
// Этот пакет больше не поддерживается - версия 12 последняя, метод теперь находится в основном пакете AutoMapper
// При обновлении AutoMapper с версии 12 до 13+ следует удалить добавленный мной пакет и добавить просто AutoMapper