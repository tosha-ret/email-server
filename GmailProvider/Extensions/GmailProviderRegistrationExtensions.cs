using EmailServer.Application;
using GmailProvider.Consumers;
using GmailProvider.Options;
using GmailProvider.Senders;
using Google.Apis.Gmail.v1.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GmailProvider.Extensions;

/// <summary>
/// Расширение для регистрации провайдера Gmail почтового сервера
/// </summary>
public static class GmailProviderRegistrationExtensions
{
    /// <summary>
    ///     Добавляет в DI сервисы уровня GmailProvider
    /// </summary>
    /// <param name="services"> Сервисы DI</param>
    /// <param name="configuration"> Конфигурация приложения </param>
    /// <returns> Возвращает DI с добавленными сервисами</returns>
    public static IServiceCollection AddGmailProviderLayer(this IServiceCollection services, IConfiguration configuration)
    {
        return services
            .Configure<GmailOptions>(configuration.GetSection(nameof(GmailOptions)))
            .AddSingleton<ISender<TextEmail>, TextSender>()
            .AddScoped<IRequestHandler<EmailConsumerRequest, IList<Message>>, GmailEmailConsumer>()
            .AddScoped<IEmailSubjectConsumer, EmailSubjectConsumer>();
    }
}