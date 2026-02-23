namespace EmailServer.Postgres.Models;

public sealed class ServiceCompanyEntity
{
	public required Guid Id { get; set; }

	public required string ShortName { get; set; }

	public required string Name { get; set; }

	public required string Email { get; set; }

	public required long PhoneNumber { get; set; }
}