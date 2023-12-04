using System.Globalization;

namespace EmailServer.Application.PekMetering;

/// <summary>
///     Методы расширения для работы с периодом
/// </summary>
public static class PeriodExtensions
{
    /// <summary>
    ///     Получает называние месяца по его номеру в нижнем регистре
    /// </summary>
    /// <param name="period"></param>
    /// <returns></returns>
    public static string GetMonthName(this Period period)
    {
        return new DateTime(1, period.Month, 1).ToString("MMMM", CultureInfo.GetCultureInfo("Ru-ru")).ToLower();
    }
}