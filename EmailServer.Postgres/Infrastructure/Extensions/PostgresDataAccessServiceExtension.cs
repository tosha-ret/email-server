using EmailServer.Postgres.Data;
using EmailServer.Postgres.Infrastructure.Constants;
using EmailServer.Postgres.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Reo.Core.Database;
using Reo.Core.Hosting.DependencyInjectionExtensions;

namespace EmailServer.Postgres.Infrastructure.Extensions;

/// <summary>
/// Методы регистрации сервисов для работы с PostgresSQL
/// </summary>
public static class PostgresDataAccessServiceExtension
{
	/// <summary>
	/// Регистрирует сервисы для работы с PostgresSQL
	/// </summary>
	/// <param name="services">Экземпляр класса <see cref="IServiceCollection" /></param>
	/// <param name="configuration">Экземпляр класса <see cref="IConfiguration" /></param>
	/// <returns>Ссылка на этот экземпляр после завершения операции</returns>
	public static IServiceCollection AddPostgresDataAccessLayerServices(this IServiceCollection services, IConfiguration configuration) => services
		.AddReoDatabase<MeteringContext>(configuration, configuration.GetConnectionString(DataBaseKeys.MeteringDatabaseName))
		.AddRepositories()
		.AddReoTime();

	private static IServiceCollection AddRepositories(this IServiceCollection services) => services
		.AddScoped<IMeteringRepository, MeteringRepository>();
}