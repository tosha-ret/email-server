using EmailServer.Application;
using EmailServer.Application.PekMetering;
using GmailProvider.Options;
using Microsoft.Extensions.Options;

namespace GmailProvider.Senders;

/// <inheritdoc />
public sealed class SenderMeteringToPek : ISenderMeteringToPek
{
    private readonly ISender<TextEmail> _sender;

    private readonly PekEmailOptions _pekEmailOptions;

    /// <summary>
    ///     Инициализирует класс <see cref="SenderMeteringToPek" />
    /// </summary>
    /// <param name="sender"></param>
    public SenderMeteringToPek(ISender<TextEmail> sender, IOptions<PekEmailOptions> options)
    {
        _sender = sender;
        _pekEmailOptions = options.Value;
    }

    /// <inheritdoc />
    public Task SendAsync(Metering metering, CancellationToken token)
    {
        var month = metering.Period.GetMonthName();

        var subject = $"Показания ИПУ {_pekEmailOptions.MeteringAddress}, {month} {metering.Period.Year}";

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
            $"Горячее водоснабжение ({metering.OldMeters.HotWater}) {metering.NewMeters.HotWater} - расход {metering.NewMeters.HotWater - metering.OldMeters.HotWater}" +
            $"{Environment.NewLine}" +
            $"{Environment.NewLine}" +
            $"Холодное водоснабжение  ({metering.OldMeters.ColdWater}) {metering.NewMeters.ColdWater} - расход {metering.NewMeters.ColdWater - metering.OldMeters.ColdWater}" +
            $"{Environment.NewLine}" +
            $"{Environment.NewLine}" +
            $"Электроэнергия ({metering.OldMeters.Electricity}) {metering.NewMeters.Electricity} - расход {metering.NewMeters.Electricity - metering.OldMeters.Electricity}" +
            $"{Environment.NewLine}" +
            $"{Environment.NewLine}" +
            $"{sign}";


        // var email = new TextEmail("info@ooopek.com", subject, text);
        var email = new TextEmail(_pekEmailOptions.Addressee, subject, text);

        return _sender.SendAsync(email, token);
    }
}