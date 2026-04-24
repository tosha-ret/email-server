using System.Globalization;
using EmailServer.Domain;

namespace EmailServer.Application.Extensions;

/// <summary>
/// Методы расширения для работы с периодом
/// </summary>
public static class PeriodExtensions
{
	/// <summary>
	/// Получает называние месяца по его номеру в нижнем регистре
	/// </summary>
	/// <param name="period">Период для отправки показаний</param>
	/// <returns>Название месяца</returns>
	public static string GetMonthName(this Period period) => new DateTime(1, period.Month, 1)
		.ToString("MMMM", CultureInfo.GetCultureInfo("Ru-ru"))
		.ToLower();
}