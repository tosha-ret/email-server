using EmailServer.Application.Extensions;
using EmailServer.Postgres.Repositories;
using Reo.Core.Extensions;

namespace EmailServer.Application.PekMetering;

public class PekMeteringService(IMeteringRepository meteringRepository) : IMeteringService
{
	//TODO: заменить на значение из БД
	private Guid _pekProviderId = Guid.Parse("c0922377-d913-4533-b32c-8c9ef46a45bc");

	public Task<MeteringView?> GetLastAsync(Guid providerId, CancellationToken token) => meteringRepository.GetLastAsync(providerId, token)
		.ThenAsync(model => model?.ToView());

	public Task SaveAsync(MeteringView meteringView, CancellationToken token)
	{
		var model = meteringView.ToModel();

		return meteringRepository.CreateAsync(_pekProviderId, model, token);
	}
}