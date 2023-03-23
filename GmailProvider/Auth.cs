using System.IO.Abstractions;
using GmailAPIHelper;
using Google.Apis.Gmail.v1;

namespace GmailProvider;

public sealed class Auth
{
    private readonly IFileSystem _fileSystem;

    public Auth(IFileSystem fileSystem)
    {
        _fileSystem = fileSystem;
    }

    public GmailService CreateToken()
    {
        return GmailHelper.GetGmailService("EmailServer",
            tokenPath: _fileSystem.Path.Combine(_fileSystem.Directory.GetCurrentDirectory(),
                "wrealle_gmail_provider_token.json"));
    }
}