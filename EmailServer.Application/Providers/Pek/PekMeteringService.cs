using EmailServer.Application.Common;
using EmailServer.Postgres.Repositories;

namespace EmailServer.Application.Providers.Pek;

/// <summary>
/// Сервис для работы с показаниями приборов учёта для провайдера ООО ПЭК
/// </summary>
/// <param name="meteringRepository">Репозиторий для работы с показаниями приборов учёта</param>
public class PekMeteringService(IMeteringRepository meteringRepository) : MeteringServiceBase(meteringRepository)
{
	/// <inheritdoc />
	protected override Guid GetProviderId() => Guid.Parse("c0922377-d913-4533-b32c-8c9ef46a45bc");
}