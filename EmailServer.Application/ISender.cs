namespace EmailServer.Application;

/// <summary>
///     Контракт для реализации отправления писем
/// </summary>
/// <typeparam name="TEmail">Тип отправляемого сообщения</typeparam>
public interface ISender<TEmail>
{
    /// <summary>
    ///     Отправляет письмо по указанным в модели <see cref="TEmail" /> параметрам
    /// </summary>
    /// <param name="email"> Параметры отправки письма </param>
    /// <param name="token"> Токен отмены </param>
    /// <returns></returns>
    Task SendAsync(TEmail email, CancellationToken token);
}