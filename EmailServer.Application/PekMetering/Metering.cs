namespace EmailServer.Application.PekMetering;

/// <summary>
/// Показания приборов учета
/// </summary>
public class Metering
{
    /// <summary>
    ///     Инициализирует новый экземпляр <see cref="Metering" />
    /// </summary>
    /// <param name="period"></param>
    /// <param name="oldMeters"></param>
    /// <param name="newMeters"></param>
    public Metering(Period period, Meters oldMeters, Meters newMeters)
    {
        Period = period;
        OldMeters = oldMeters;
        NewMeters = newMeters;
    }

    /// Период, закоторый подаются показания
    public Period Period { get; private set; }

    /// Показания предыдущего периода
    public Meters OldMeters { get; private set; }

    /// Показания текущего периода
    public Meters NewMeters { get; private set; }
}