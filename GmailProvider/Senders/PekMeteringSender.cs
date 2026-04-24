using EmailServer.Application;
using EmailServer.Application.Common;
using EmailServer.Application.Common.Models;
using EmailServer.Application.Extensions;
using GmailProvider.Options;
using Microsoft.Extensions.Options;

namespace GmailProvider.Senders;

/// <inheritdoc />
public sealed class PekMeteringSender : IMeteringSender
{
	private readonly PekEmailOptions _pekEmailOptions;

	private readonly ISender<TextEmail> _sender;

	private readonly IMeteringService _meteringService;

	/// <summary>
	/// Инициализирует класс <see cref="PekMeteringSender" />
	/// </summary>
	/// <param name="sender">Сервис отправки писем</param>
	/// <param name="options">Настройки отправки писем</param>
	/// <param name="meteringService">Сервис работы с показаниями приборов учёта</param>
	public PekMeteringSender(
		ISender<TextEmail> sender,
		IOptions<PekEmailOptions> options,
		IMeteringService meteringService)
	{
		_sender = sender;
		_meteringService = meteringService;
		_pekEmailOptions = options.Value;
	}

	/// <inheritdoc />
	public async Task SendAsync(MeteringView meteringView, CancellationToken token)
	{
		var lastData = await _meteringService.GetLastAsync(token)
						?? throw new("Показания прошлого периода не найдены");

		var oldMeters = lastData.Meters;

		var month = meteringView.Period.GetMonthName();

		var subject = $"Показания ИПУ {_pekEmailOptions.MeteringAddress}, {month} {meteringView.Period.Year}";

		var sign = $"--"
					+ $"{Environment.NewLine}"
					+ $"{_pekEmailOptions.Signature.Name},"
					+ $"{Environment.NewLine}"
					+ $"тел.: {_pekEmailOptions.Signature.Phone}"
					+ $"{Environment.NewLine}"
					+ $"e-mail: {_pekEmailOptions.Signature.Email}";

		var text =
			$"Показания приборов учёта {_pekEmailOptions.MeteringAddress} за {month}:"
			+ $"{Environment.NewLine}"
			+ $"{Environment.NewLine}"
			+ $"Горячее водоснабжение ({oldMeters.HotWater}) {meteringView.Meters.HotWater} - расход {meteringView.Meters.HotWater - oldMeters.HotWater}"
			+ $"{Environment.NewLine}"
			+ $"{Environment.NewLine}"
			+ $"Холодное водоснабжение  ({oldMeters.ColdWater}) {meteringView.Meters.ColdWater} - расход {meteringView.Meters.ColdWater - oldMeters.ColdWater}"
			+ $"{Environment.NewLine}"
			+ $"{Environment.NewLine}"
			+ $"Электроэнергия ({oldMeters.Electricity}) {meteringView.Meters.Electricity} - расход {meteringView.Meters.Electricity - oldMeters.Electricity}"
			+ $"{Environment.NewLine}"
			+ $"{Environment.NewLine}"
			+ $"{sign}";

		var email = new TextEmail(_pekEmailOptions.Addressee, subject, text);

		await _sender.SendAsync(email, token);

		await _meteringService.SaveAsync(meteringView, token);
	}
}