using EmailServer.Domain;
using EmailServer.Postgres.Data;
using EmailServer.Postgres.Infrastructure.Extensions;
using EmailServer.Postgres.Models;
using Microsoft.EntityFrameworkCore;
using Reo.Core.Extensions;
using Reo.Core.Hosting.ReoTime;
using Reo.Core.PredicateBuilder;

namespace EmailServer.Postgres.Repositories;

/// <summary>
/// Репозиторий для работы с показаниями приборов учёта
/// </summary>
public class MeteringRepository(
	IDbContextFactory<MeteringContext> dbContextFactory,
	IReoPredicateBuilderFactory predicateFactory,
	IReoUtcTimeService utcTimeService)
	: IMeteringRepository
{
	/// <inheritdoc />
	public async Task CreateAsync(
		Guid providerId,
		Metering metering,
		CancellationToken token)
	{
		await using var context = await dbContextFactory.CreateDbContextAsync(token);

		var predicate = predicateFactory.Create<MeteringEntity>()
			.BeEqualTo(o => o.ReportYear, metering.ReportPeriod.Year)
			.BeEqualTo(o => o.ReportMonth, metering.ReportPeriod.Month)
			.Build();

		var existMetersForPeriod = await context.Meterings.FirstOrDefaultAsync(predicate, token);

		if (existMetersForPeriod is not null)
		{
			throw new InvalidOperationException("Показания приборов учёта для указанного периода уже существуют");
		}

		await context.AddAsync(metering.ToEntity(null, providerId, utcTimeService.CurrentDateTime), token);

		await context.SaveChangesAsync(token);
	}

	/// <inheritdoc />
	public async Task<IReadOnlyCollection<Metering>> GetByFilterAsync(
		Guid providerId,
		MeteringFilter filter,
		CancellationToken token)
	{
		await using var context = await dbContextFactory.CreateDbContextAsync(token);

		var predicate = predicateFactory.Create<MeteringEntity>()
			.BeEqualTo(x => x.ProviderId, providerId)
			.When(filter.Year is not null, b => b.BeEqualTo(o => o.ReportYear, filter.Year))
			.When(filter.Month is not null, b => b.BeEqualTo(o => o.ReportMonth, filter.Month));

		return await context.Meterings
			.Where(predicate.Build())
			.OrderByDescending(x => x.ReportYear)
			.ThenBy(x => x.ReportMonth)
			.ToListAsync(token)
			.ThenAsync(entity => entity.Select(s => s.ToDomain())
				.ToList());
	}

	/// <inheritdoc />
	public async Task<Metering?> GetLastAsync(Guid providerId, CancellationToken token)
	{
		await using var context = await dbContextFactory.CreateDbContextAsync(token);

		var predicate = predicateFactory.Create<MeteringEntity>()
			.BeEqualTo(x => x.ProviderId, providerId);

		return await context.Meterings
			.Where(predicate.Build())
			.OrderByDescending(x => x.ReportYear)
			.ThenByDescending(x => x.ReportMonth)
			.FirstOrDefaultAsync(token)
			.ThenAsync(entity => entity?.ToDomain());
	}
}