using Microsoft.Extensions.DependencyInjection;

namespace EmailServer.Application;

/// <summary>
///     Класс расширения для регистрации сервисов слоя приложения
/// </summary>
public static class ApplicationLayerRegistrationExtensions
{
    /// <summary>
    ///     Добавляет в DI сервисы уровня приложения
    /// </summary>
    /// <param name="services"> Сервисы DI</param>
    /// <returns> Возвращает DI с добавленными сервисами</returns>
    public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
    {
        return services;
    }
}