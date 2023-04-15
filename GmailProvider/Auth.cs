using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Util.Store;

namespace GmailProvider;

public sealed class Auth
{
    public async Task<UserCredential> GetCredentialAsync(CancellationToken token)
    {
        await using var stream = new FileStream("client_secrets.json", FileMode.Open, FileAccess.Read);

        var googleClientSecrets = await GoogleClientSecrets.FromStreamAsync(stream, token);
        
        

        return await GoogleWebAuthorizationBroker.AuthorizeAsync(
            googleClientSecrets.Secrets,
            new[] { GmailService.Scope.GmailSend },
            "tosharet@gmail.com", token, new FileDataStore("Emails.Wrealle"));
    }
}