using EmailServer.Domain;
using EmailServer.Postgres.Data;
using EmailServer.Postgres.Infrastructure.Extensions;
using EmailServer.Postgres.Models;
using Microsoft.EntityFrameworkCore;
using Reo.Core.Extensions;
using Reo.Core.Hosting.ReoTime;
using Reo.Core.PredicateBuilder;

namespace EmailServer.Postgres.Repositories;

public class PekMeteringRepository(
	IDbContextFactory<MeteringContext> dbContextFactory,
	IReoPredicateBuilderFactory predicateFactory,
	IReoUtcTimeService utcTimeService)
	: IMeteringRepository
{
	public async Task CreateAsync(
		Guid providerId,
		Metering metering,
		CancellationToken token)
	{
		await using var context = await dbContextFactory.CreateDbContextAsync(token);

		await context.AddAsync(metering.ToEntity(null, providerId, utcTimeService.CurrentDateTime), token);

		await context.SaveChangesAsync(token);
	}

	public async Task<Metering?> GetLastAsync(Guid providerId, CancellationToken token)
	{
		await using var context = await dbContextFactory.CreateDbContextAsync(token);

		var predicate = predicateFactory.Create<MeteringEntity>()
			.BeEqualTo(x => x.ProviderId, providerId);

		return await context.Meterings
			.Where(predicate.Build())
			.OrderByDescending(x => x.CreateDate)
			.FirstOrDefaultAsync(token)
			.ThenAsync(entity => entity?.ToDomain());
	}
}