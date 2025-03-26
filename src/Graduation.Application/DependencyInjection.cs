using Microsoft.Extensions.DependencyInjection;

namespace Graduation.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services
            .AddAutoMapper(typeof(DependencyInjection).Assembly) // AutoMapper
            .AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly)); // MediatR
        return services;
    }
}

// TODO:
// Для метода AddAutoMapper добавил в проект AutoMapper.Extensions.Microsoft.DependencyInjection
// Этот пакет больше не поддерживается - версия 12 последняя, метод теперь находится в основном пакете AutoMapper
// При обновлении AutoMapper с версии 12 до 13+ следует удалить добавленный мной пакет и добавить просто AutoMapper