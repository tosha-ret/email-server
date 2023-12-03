using System.Collections.ObjectModel;

namespace EmailServer.Application;

public interface IEmailSubjectConsumer
{
    Task<ReadOnlyCollection<string>> GetEmailsAsync(CancellationToken token);
}