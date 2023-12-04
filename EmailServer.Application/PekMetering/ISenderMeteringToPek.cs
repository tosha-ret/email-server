namespace EmailServer.Application.PekMetering;

/// <summary>
/// Сервис для отправки показаний приборов учета в УК ПЭК
/// </summary>
public interface ISenderMeteringToPek
{
    /// <summary>
    /// Отправляет показания на электронную почту УК ПЭК
    /// </summary>
    /// <param name="metering">Показания</param>
    /// <param name="token">Токен отмены</param>
    /// <returns></returns>
    Task SendAsync(Metering metering,  CancellationToken token);
}