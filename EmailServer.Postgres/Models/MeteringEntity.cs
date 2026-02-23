namespace EmailServer.Postgres.Models;

public sealed class MeteringEntity
{
	public required Guid Id { get; set; }

	public required Guid ProviderId { get; set; }

	public required DateTime SendingDate { get; set; }

	public required decimal HotWater { get; set; }

	public required decimal ColdWater { get; set; }

	public required decimal Electricity { get; set; }
}