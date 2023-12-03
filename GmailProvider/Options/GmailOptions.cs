namespace GmailProvider.Options;

/// <summary>
/// Секция для настроек отправки писем для Gmail провайдера
/// </summary>
public sealed class GmailOptions
{
    /// <summary>
    /// Настройки отправителя
    /// </summary>
    public SenderOptions Sender { get; set; }

    /// <summary>
    /// Настройки SMTP сервера
    /// </summary>
    public SmtpClientOptions SmtpClient { get; set; }
}