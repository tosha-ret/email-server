namespace GmailProvider.Options;

/// <summary>
/// Настройки SMTP сервера для отправки писем
/// </summary>
public sealed class SmtpClientOptions
{
    /// <summary>
    /// Адрес SMTP сервера
    /// </summary>
    public string Host { get; set; }
    /// <summary>
    /// Порт SMTP сервера
    /// </summary>
    public int Port { get; set; }
    /// <summary>
    /// Включить SSL
    /// </summary>
    public bool EnableSsl { get; set; }
}