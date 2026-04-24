namespace EmailServer.Application.Common.Models;

/// <summary>
/// Фильтр для получения ранее введённых показаний приборов учёта
/// </summary>
/// <param name="Year">Год</param>
/// <param name="Month">Месяц</param>
public record MeteringFilterView(int? Year, int? Month);