namespace EmailServer.Application.PekMetering;

/// <summary>
/// Модель показаний индивидуальных приборов учёта
/// </summary>
/// <param name="HotWater">Горячая вода</param>
/// <param name="ColdWater">Холодная вода</param>
/// <param name="Electricity">Электроэнергия</param>
public record Meters(decimal HotWater, decimal ColdWater, decimal Electricity);