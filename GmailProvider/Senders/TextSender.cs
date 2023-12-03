using System.Net;
using System.Net.Mail;
using EmailServer.Application;
using GmailProvider.Options;
using Microsoft.Extensions.Options;

namespace GmailProvider.Senders;

/// <inheritdoc />
public sealed class TextSender : ISender<TextEmail>
{
    private readonly SmtpClientOptions _client;

    private readonly SenderOptions _sender;

    /// <summary>
    ///     Инициализирует класс <see cref="TextSender" />
    /// </summary>
    /// <param name="gmailOptions"></param>
    public TextSender(IOptions<GmailOptions> gmailOptions)
    {
        _sender = gmailOptions.Value.Sender;
        _client = gmailOptions.Value.SmtpClient;
    }

    /// <inheritdoc />
    public Task SendAsync(TextEmail email, CancellationToken token)
    {
        using var message = new MailMessage(_sender.Address, email.Addresee, email.Subject, email.Message);

        using var client = new SmtpClient(_client.Host, _client.Port);

        client.EnableSsl = _client.EnableSsl;

        client.Credentials = new NetworkCredential(_sender.Address, _sender.AppPassword);

        if (token.IsCancellationRequested)
        {
            return Task.FromCanceled(token);
        }

        client.Send(message);

        return Task.CompletedTask;
    }
}