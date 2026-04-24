using EmailServer.Application.Common.Models;
using EmailServer.Application.Extensions;
using EmailServer.Domain;
using EmailServer.Postgres.Repositories;
using Reo.Core.Extensions;

namespace EmailServer.Application.Common;

/// <summary>
/// Базовый сервис для работы с показаниями приборов учёта
/// </summary>
public abstract class MeteringServiceBase(IMeteringRepository meteringRepository) : IMeteringService
{
	/// <inheritdoc />
	public Task<MeteringView?> GetLastAsync(CancellationToken token) => meteringRepository.GetLastAsync(GetProviderId(), token)
		.ThenAsync(model => model?.ToView());

	/// <inheritdoc />
	public async Task<IReadOnlyCollection<MeteringView>> GetByFilterAsync(
		MeteringFilterView filter,
		CancellationToken token) => await meteringRepository.GetByFilterAsync(GetProviderId(), filter.ToModel(), token)
		.ThenAsync(model => model.Select<Metering, MeteringView>(s => s.ToView())
			.ToList());

	/// <inheritdoc />
	public Task SaveAsync(MeteringView meteringView, CancellationToken token)
	{
		var model = meteringView.ToModel();

		return meteringRepository.CreateAsync(GetProviderId(), model, token);
	}

	/// <summary>
	/// Получить идентификатор провайдера
	/// </summary>
	/// <returns>Идентификатор провайдера</returns>
	protected abstract Guid GetProviderId();
}