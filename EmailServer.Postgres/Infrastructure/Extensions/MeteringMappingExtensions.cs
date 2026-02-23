using EmailServer.Domain;
using EmailServer.Postgres.Models;

namespace EmailServer.Postgres.Infrastructure.Extensions;

public static class MeteringMappingExtensions
{
	public static Metering ToDomain(this MeteringEntity entity) => Metering.Restore(entity.HotWater, entity.ColdWater, entity.Electricity, entity.SendingDate);

	public static MeteringEntity ToEntity(
		this Metering metering,
		Guid? id,
		Guid providerId,
		DateTime sendingDate) => new MeteringEntity
	{
		Id = id ?? Guid.NewGuid(),
		ProviderId = providerId,
		SendingDate = sendingDate,
		HotWater = metering.HotWater,
		ColdWater = metering.ColdWater,
		Electricity = metering.Electricity
	};
}