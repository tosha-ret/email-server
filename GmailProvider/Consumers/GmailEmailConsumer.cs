using EmailServer.Application;
using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;
using Google.Apis.Services;

namespace GmailProvider.Consumers;

/// <summary>
///     Получатель писем для Gmail почтового сервера
/// </summary>
public sealed class GmailEmailConsumer : IRequestHandler<EmailConsumerRequest, IList<Message>>
{
    // private readonly GmailService _service;

    /// <summary>
    ///     Инициализирует получателя писем
    /// </summary>
    public GmailEmailConsumer()
    {
        // Авторизация с помощью OAuth 2.0 
        // //"credentials.json"
        // var credential = GoogleCredential.FromFile("client_secrets.json")
        //     .CreateScoped(GmailService.Scope.GmailReadonly);
        // _service = new GmailService(new BaseClientService.Initializer
        // {
        //     HttpClientInitializer = credential
        // });

        
        //
        //
        // gmailService.Users.Messages.Send(new Message
        // {
        //     Payload = new MessagePart
        //     {
        //         Body = new MessagePartBody
        //             { Data = email.Message }
        //     }
        // }, "me");
    }

    /// <inheritdoc />
    public async Task<IList<Message>> ExecuteAsync(EmailConsumerRequest request, CancellationToken token)
    
    {
        var service = await GetServiceAsync(token);
        // Получение списка писем
        var gmailRequest = service.Users.Messages.List(request.BoxName);

        gmailRequest.MaxResults = request.Take;

        var response = await gmailRequest.ExecuteAsync(token);

        return response.Messages;
    }

    private async Task<GmailService> GetServiceAsync(CancellationToken token)
    {
        var auth = new Auth();
        var configurableHttpClientInitializer = await auth.GetCredentialAsync(token);
        return new GmailService(new BaseClientService.Initializer
        {
            HttpClientInitializer = configurableHttpClientInitializer,
            ApplicationName = "EmailServer"
        });
    }

    private static void Get()
    {
        // // Подключение к серверу Gmail
        // using (var client = new ImapClient())
        // {
        //     client.Connect("imap.gmail.com", 993, SecureSocketOptions.SslOnConnect);
        //
        //     // Аутентификация
        //     string email = "your_email@gmail.com";
        //     string password = "your_password";
        //     client.Authenticate(email, password);
        //
        //     // Выбор почтового ящика
        //     client.Inbox.Open(FolderAccess.ReadOnly);
        //
        //     // Поиск писем
        //     var uids = client.Inbox.Search(SearchQuery.All);
        //
        //     // Получение информации о письмах
        //     foreach (var uid in uids)
        //     {
        //         var message = client.Inbox.GetMessage(uid);
        //         Console.WriteLine(message.Subject);
        //     }
        //
        //     // Закрытие соединения
        //     client.Disconnect(true);
        // }
    }
}