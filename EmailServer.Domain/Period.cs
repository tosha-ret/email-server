namespace EmailServer.Domain;

/// <summary>
/// Период для отправки показаний
/// </summary>
/// <param name="Year">Год</param>
/// <param name="Month">Месяц</param>
public sealed record Period(int Year, int Month);