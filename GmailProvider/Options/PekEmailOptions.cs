namespace GmailProvider.Options;

/// <summary>
/// Настройки отправления пиьма с показаниями приборов учета в УК ПЭК
/// </summary>
public sealed class PekEmailOptions
{ 
    /// <summary> Почтовый адрес получателя</summary>
    public string Addressee { get; set; }

    /// <summary>Адрес объекта, где расположены приборы учета</summary>
    public string MeteringAddress { get; set; }

    /// <summary>Подпись отправителя</summary>
    public Signature Signature { get; set; }
}