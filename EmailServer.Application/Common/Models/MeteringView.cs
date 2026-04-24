using EmailServer.Domain;

namespace EmailServer.Application.Common.Models;

/// <summary>
/// Модель отображения для создания записи показаний приборов учета
/// </summary>
public class MeteringView
{
	/// <summary>
	///     Инициализирует новый экземпляр <see cref="MeteringView" />
	/// </summary>
	/// <param name="period">Период для отправки показаний</param>
	/// <param name="meters">Модель показаний индивидуальных приборов учёта</param>
	public MeteringView(Period period, Meters meters)
	{
		Period = period;
		Meters = meters;
	}

	/// Период, за который подаются показания
	public Period Period { get; private set; }

	/// Показания периода
	public Meters Meters { get; private set; }
}