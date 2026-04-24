using EmailServer.Application.Common.Models;

namespace EmailServer.Application.Common;

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
    Task SendAsync(MeteringView meteringView,  CancellationToken token);
}