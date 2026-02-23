namespace EmailServer.Application.PekMetering;

/// <summary>
/// Сервис для отправки показаний приборов учета в УК ПЭК
/// </summary>
public interface IMeteringSender
{
    /// <summary>
    /// Отправляет показания на электронную почту УК ПЭК
    /// </summary>
    /// <param name="meteringView">Показания</param>
    /// <param name="token">Токен отмены</param>
    /// <returns></returns>
    Task SendAsync(MeteringView meteringView,  CancellationToken token);
}