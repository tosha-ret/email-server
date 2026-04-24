using EmailServer.Domain;

namespace EmailServer.Postgres.Repositories;

/// <summary>
/// Интерфейс репозитория для работы с показаниями приборов учёта
/// </summary>
public interface IMeteringRepository
{
	/// <summary>
	/// Добавить запись с показаниями приборов учёта за указанный период для указанного провайдера
	/// </summary>
	/// <param name="providerId">Идентификатор провайдера</param>
	/// <param name="metering">Показания приборов учёта</param>
	/// <param name="token">Токен отмены операции</param>
	Task CreateAsync(
		Guid providerId,
		Metering metering,
		CancellationToken token);

	/// <summary>
	/// Получить показания по фильтру для указанного провайдера
	/// </summary>
	/// <param name="providerId">Идентификатор провайдера</param>
	/// <param name="filter">Фильтр</param>
	/// <param name="token">Токен отмены операции</param>
	/// <returns>Список показаний согласно фильтра</returns>
	Task<IReadOnlyCollection<Metering>> GetByFilterAsync(
		Guid providerId,
		MeteringFilter filter,
		CancellationToken token);

	/// <summary>
	/// Получить последние по периоду показания
	/// </summary>
	/// <param name="providerId">Идентификатор провайдера</param>
	/// <param name="token">Токен отмены операции</param>
	/// <returns>Последние по периоду показания</returns>
	Task<Metering?> GetLastAsync(Guid providerId, CancellationToken token);
}