namespace GmailProvider;

/// <summary>
/// Модель запроса на получение писем
/// </summary>
/// <param name="BoxName">Имя проверяемого почтового ящика</param>
/// <param name="Take">Количество получаемых писем</param>
public record EmailRecieverRequest(string BoxName, int Take);