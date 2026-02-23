namespace EmailServer.Application.PekMetering;

public interface IMeteringService
{
	Task<MeteringView?> GetLastAsync(Guid providerId, CancellationToken token);

	Task SaveAsync(MeteringView meteringView, CancellationToken token);
}