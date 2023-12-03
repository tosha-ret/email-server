using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;
using Google.Apis.Services;

namespace GmailProvider;

/// <summary>
///     Получатель писем для Gmail почтового сервера
/// </summary>
public sealed class GmailEmailConsumer : IRequestHandler<EmailRecieverRequest, IList<Message>>
{
    private readonly GmailService _service;

    /// <summary>
    ///     Инициализирует получателя писем
    /// </summary>
    public GmailEmailConsumer()
    {
        // Авторизация с помощью OAuth 2.0 
        //"credentials.json"
        var credential = GoogleCredential.FromFile("client_secrets.json")
            .CreateScoped(GmailService.Scope.GmailReadonly);
        _service = new GmailService(new BaseClientService.Initializer
        {
            HttpClientInitializer = credential
        });

        // var auth = new Auth();
        // var configurableHttpClientInitializer = await auth.GetCredentialAsync(token);
        // var gmailService = new GmailService(new BaseClientService.Initializer
        // {
        //     HttpClientInitializer = configurableHttpClientInitializer,
        //     ApplicationName = "EmailServer"
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
    public async Task<IList<Message>> ExecuteAsync(EmailRecieverRequest request, CancellationToken token)
    {
        // Получение списка писем
        var gmailRequest = _service.Users.Messages.List(request.BoxName);


        gmailRequest.MaxResults = request.Take;

        var response = await gmailRequest.ExecuteAsync(token);


        return response.Messages;
    }
}