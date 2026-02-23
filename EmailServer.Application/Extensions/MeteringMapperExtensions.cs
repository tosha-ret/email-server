using EmailServer.Application.PekMetering;
using EmailServer.Domain;

namespace EmailServer.Application.Extensions;

public static class MeteringMapperExtensions
{
	public static MeteringView ToView(this Metering metering)
	{
		return new(metering.ReportPeriod, new(metering.HotWater, metering.ColdWater, metering.Electricity), new(0, 0, 0));
	}

	public static Metering ToModel(this MeteringView view)
	{
		return Metering.Create(view.NewMeters.HotWater, view.NewMeters.ColdWater, view.NewMeters.Electricity, view.Period);
	}
}