namespace GmailProvider.Options;

/// <summary>
///     Параметры отправителя письма
/// </summary>
/// <param name="Address">Адрес электронной почты отправителя</param>
/// <param name="AppPassword">Пароль приложения при двухфакторной авторизации</param>
public record SenderOptions(string Address, string AppPassword);