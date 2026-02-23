using EmailServer.Postgres.Infrastructure.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace EmailServer.Postgres.Data;

/// <inheritdoc cref="IDbContextFactory{TContext}"/>
internal sealed class MeteringDbContextFactory : IDesignTimeDbContextFactory<MeteringContext>, IDbContextFactory<MeteringContext>
{
    /// <inheritdoc />
    public MeteringContext CreateDbContext(string[] args)
    {
        var configurationBuilder = new ConfigurationBuilder();

        var configurationRoot = configurationBuilder
            .AddJsonFile("appsettings.json")
            .AddEnvironmentVariables()
            .AddCommandLine(args)
            .AddUserSecrets("2127bfd8-e8b2-4816-9541-26cf82db6399")
            .Build();

        var optionsBuilder = new DbContextOptionsBuilder<MeteringContext>();

        optionsBuilder.UseNpgsql(configurationRoot.GetConnectionString(DataBaseKeys.MeteringDatabaseName));

        return new(optionsBuilder.Options);
    }

    /// <inheritdoc />
    public MeteringContext CreateDbContext() => CreateDbContext([]);
}