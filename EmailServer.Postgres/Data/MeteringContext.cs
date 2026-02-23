using EmailServer.Postgres.Models;
using EmailServer.Postgres.Modules.ServiceCompanies.Configurations;
using Microsoft.EntityFrameworkCore;

namespace EmailServer.Postgres.Data;

public class MeteringContext : DbContext
{
	/// <summary>
	/// Инициализирует новый экземпляр класса <see cref="MeteringContext" />
	/// </summary>
	public MeteringContext(DbContextOptions<MeteringContext> options) : base(options)
	{
	}

	/// <summary>
	/// Обслуживающие компании
	/// </summary>
	public DbSet<ServiceCompanyEntity> ServiceCompanies { get; set; }

	/// <summary>
	/// Показания
	/// </summary>
	public DbSet<MeteringEntity> Meterings { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfiguration(new ServiceCompanyConfiguration());
	}
}