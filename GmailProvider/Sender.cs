using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;
using Google.Apis.Services;

namespace GmailProvider;

public sealed class Sender
{
    public async Task SendAsync(TextEmail email, CancellationToken token)
    {
        var auth = new Auth();
        var configurableHttpClientInitializer = await auth.GetCredentialAsync(token);
        var gmailService = new GmailService(new BaseClientService.Initializer
        {
            HttpClientInitializer = configurableHttpClientInitializer,
            ApplicationName = "EmailServer"
        });


        gmailService.Users.Messages.Send(new Message
        {
            Payload = new MessagePart
            {
                Body = new MessagePartBody
                    { Data = email.Message }
            }
        }, "me");
    }
}