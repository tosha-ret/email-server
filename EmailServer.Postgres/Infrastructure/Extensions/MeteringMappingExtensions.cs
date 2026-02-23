using EmailServer.Domain;
using EmailServer.Postgres.Models;

namespace EmailServer.Postgres.Infrastructure.Extensions;

public static class MeteringMappingExtensions
{
	public static Metering ToDomain(this MeteringEntity entity) => Metering.Restore(entity.HotWater, entity.ColdWater, entity.Electricity,
		new(entity.ReportYear, entity.ReportMonth), entity.CreateDate);

	public static MeteringEntity ToEntity(
		this Metering metering,
		Guid? id,
		Guid providerId,
		DateTime createDate) => new()
	{
		Id = id ?? Guid.NewGuid(),
		ProviderId = providerId,
		CreateDate = createDate,
		ReportYear = metering.ReportPeriod.Year,
		ReportMonth = metering.ReportPeriod.Month,
		HotWater = metering.HotWater,
		ColdWater = metering.ColdWater,
		Electricity = metering.Electricity
	};
}