using GmailAPIHelper;

namespace GmailProvider;

public sealed class Sender
{
    public void Send(TextEmail email)
    {
        var service = GmailHelper.GetGmailService("EmailServer");

        service.SendMessage(GmailHelper.EmailContentType.PLAIN, email.Addresee, subject: email.Subject,
            body: email.Message);
    }
}