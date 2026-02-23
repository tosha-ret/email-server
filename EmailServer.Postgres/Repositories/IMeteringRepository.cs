using EmailServer.Domain;

namespace EmailServer.Postgres.Repositories;

public interface IMeteringRepository
{
	Task CreateAsync(Guid providerId, Metering metering, CancellationToken token);

	Task<Metering?> GetLastAsync(Guid providerId,  CancellationToken token);
}