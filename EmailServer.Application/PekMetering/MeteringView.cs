using EmailServer.Domain;

namespace EmailServer.Application.PekMetering;

/// <summary>
/// Показания приборов учета
/// </summary>
public class MeteringView
{
    /// <summary>
    ///     Инициализирует новый экземпляр <see cref="MeteringView" />
    /// </summary>
    /// <param name="period"></param>
    /// <param name="oldMeters"></param>
    /// <param name="newMeters"></param>
    public MeteringView(Period period, Meters oldMeters, Meters newMeters)
    {
        Period = period;
        OldMeters = oldMeters;
        NewMeters = newMeters;
    }

    /// Период, за который подаются показания
    public Period Period { get; private set; }

    /// Показания предыдущего периода
    public Meters OldMeters { get; private set; }

    /// Показания текущего периода
    public Meters NewMeters { get; private set; }
}