namespace GmailProvider;

/// <summary>
///     Контракт для реализации получения писем
/// </summary>
/// <typeparam name="TRequest">Тип запроса на получение писем</typeparam>
/// <typeparam name="TResponse">Тип ответа от почтового сервиса</typeparam>
public interface IRequestHandler<TRequest, TResponse>
{
    /// <summary>
    ///     Отправляет запрс <see cref="TRequest" /> на обработку писем
    /// </summary>
    /// <param name="request"> Параметры запроса к почтовому сервису </param>
    /// <param name="token"> Токен отмены </param>
    /// <returns> Возвращает ответ от почтового сервиса </returns>
    Task<TResponse> ExecuteAsync(TRequest request, CancellationToken token);
}