using System.Collections.ObjectModel;
using EmailServer.Application;
using Google.Apis.Gmail.v1.Data;

namespace GmailProvider.Consumers;

/// <inheritdoc />
public sealed class EmailSubjectConsumer: IEmailSubjectConsumer
{
    private readonly IRequestHandler<EmailConsumerRequest, IList<Message>> _emailConsumer;

    /// <summary>
    /// Инициализирует экземпляр <see cref="EmailSubjectConsumer"/>
    /// </summary>
    /// <param name="emailConsumer"></param>
    public EmailSubjectConsumer(IRequestHandler<EmailConsumerRequest, IList<Message>> emailConsumer)
    {
        _emailConsumer = emailConsumer;
    }

    /// <inheritdoc />
    public async Task<ReadOnlyCollection<string>> GetEmailsAsync(CancellationToken token)
    {
        var emailConsumerRequest = new EmailConsumerRequest("me", 10);
        var response = await _emailConsumer.ExecuteAsync(emailConsumerRequest, token);
        
        return response.Select(s=> GetHeaderValue(s.Payload.Headers, "Subject")).ToList().AsReadOnly();
    }
    
    // Helper method to get a specific header value from message headers
    static string GetHeaderValue(IEnumerable<MessagePartHeader> headers, string name)
    {
        foreach (var header in headers)
        {
            if (header.Name.ToLower() == name.ToLower())
            {
                return header.Value;
            }
        }
        return "Без темы";
    }
}