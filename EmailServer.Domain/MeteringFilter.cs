namespace EmailServer.Domain;

/// <summary>
/// Фильтр для получения ранее введённых показаний приборов учёта
/// </summary>
/// <param name="Year">Год</param>
/// <param name="Month">Месяц</param>
public record MeteringFilter(int? Year, int? Month);