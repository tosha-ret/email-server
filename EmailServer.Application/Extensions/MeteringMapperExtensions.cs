using EmailServer.Application.Common.Models;
using EmailServer.Domain;

namespace EmailServer.Application.Extensions;

public static class MeteringMapperExtensions
{
	public static MeteringView ToView(this Metering metering)
	{
		return new(metering.ReportPeriod, new(metering.HotWater, metering.ColdWater, metering.Electricity));
	}

	public static Metering ToModel(this MeteringView view)
	{
		return Metering.Create(view.Meters.HotWater, view.Meters.ColdWater, view.Meters.Electricity, view.Period);
	}

	public static MeteringFilter ToModel(this MeteringFilterView view)
	{
		return new(view.Year, view.Month);
	}
}