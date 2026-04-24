using EmailServer.Application.Common.Models;

namespace EmailServer.Application.Common;

/// <summary>
/// Сервис для работы с показаниями приборов учёта
/// </summary>
public interface IMeteringService
{
	/// <summary>
	/// Получить последние по периоду сохранённые показания
	/// </summary>
	/// <param name="token">Токен отмены операции</param>
	/// <returns>
	/// Модель отображения для создания записи показаний приборов учета
	/// </returns>
	Task<MeteringView?> GetLastAsync(CancellationToken token);

	/// <summary>
	/// Получить показания приборов учёта по фильтру
	/// </summary>
	/// <param name="filter">Фильтр для получения ранее введённых показаний приборов учёта</param>
	/// <param name="token">Токен отмены операции</param>
	/// <returns>
	/// Список показаний приборов учёта согласно фильтру
	/// </returns>
	Task<IReadOnlyCollection<MeteringView>> GetByFilterAsync(MeteringFilterView filter, CancellationToken token);

	/// <summary>
	/// Сохранить показания приборов учёта
	/// </summary>
	/// <param name="meteringView">Модель отображения для создания записи показаний приборов учета</param>
	/// <param name="token">Токен отмены операции</param>
	Task SaveAsync(MeteringView meteringView, CancellationToken token);
}