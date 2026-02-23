using EmailServer.Application;
using EmailServer.Application.PekMetering;
using GmailProvider.Options;
using Microsoft.Extensions.Options;

namespace GmailProvider.Senders;

/// <inheritdoc />
public sealed class PekMeteringSender : IMeteringSender
{
    private readonly PekEmailOptions _pekEmailOptions;

    private readonly ISender<TextEmail> _sender;

	private readonly IMeteringService _meteringService;

	//TODO: заменить на значение из БД
	private Guid _pekProviderId = Guid.Parse("c0922377-d913-4533-b32c-8c9ef46a45bc");

    /// <summary>
    /// Инициализирует класс <see cref="PekMeteringSender" />
    /// </summary>
    /// <param name="sender">Сервис отправки писем</param>
    /// <param name="options">Настройки отправки писем</param>
    public PekMeteringSender(ISender<TextEmail> sender, IOptions<PekEmailOptions> options,
							IMeteringService meteringService)
    {
        _sender = sender;
		_meteringService = meteringService;
		_pekEmailOptions = options.Value;
    }

    /// <inheritdoc />
    public async Task SendAsync(MeteringView meteringView, CancellationToken token)
    {
		var lastMeters = await _meteringService.GetLastAsync(_pekProviderId, token);

		var oldMeters = lastMeters?.OldMeters ?? meteringView.OldMeters;
		var month = meteringView.Period.GetMonthName();

        var subject = $"Показания ИПУ {_pekEmailOptions.MeteringAddress}, {month} {meteringView.Period.Year}";

        var sign = $"--" +
                   $"{Environment.NewLine}" +
                   $"{_pekEmailOptions.Signature.Name}," +
                   $"{Environment.NewLine}" +
                   $"тел.: {_pekEmailOptions.Signature.Phone}" +
                   $"{Environment.NewLine}" +
                   $"e-mail: {_pekEmailOptions.Signature.Email}";

        var text =
            $"Показания приборов учёта {_pekEmailOptions.MeteringAddress} за {month}:" +
            $"{Environment.NewLine}" +
            $"{Environment.NewLine}" +
            $"Горячее водоснабжение ({oldMeters.HotWater}) {meteringView.NewMeters.HotWater} - расход {meteringView.NewMeters.HotWater - oldMeters.HotWater}" +
            $"{Environment.NewLine}" +
            $"{Environment.NewLine}" +
            $"Холодное водоснабжение  ({oldMeters.ColdWater}) {meteringView.NewMeters.ColdWater} - расход {meteringView.NewMeters.ColdWater - oldMeters.ColdWater}" +
            $"{Environment.NewLine}" +
            $"{Environment.NewLine}" +
            $"Электроэнергия ({oldMeters.Electricity}) {meteringView.NewMeters.Electricity} - расход {meteringView.NewMeters.Electricity - oldMeters.Electricity}" +
            $"{Environment.NewLine}" +
            $"{Environment.NewLine}" +
            $"{sign}";

        var email = new TextEmail(_pekEmailOptions.Addressee, subject, text);

        await _sender.SendAsync(email, token);

		await _meteringService.SaveAsync(meteringView, token);
    }
}