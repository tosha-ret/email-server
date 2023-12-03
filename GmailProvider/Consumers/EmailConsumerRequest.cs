namespace GmailProvider.Consumers;

/// <summary>
/// Модель запроса на получение писем
/// </summary>
/// <param name="BoxName">Имя проверяемого почтового ящика</param>
/// <param name="Take">Количество получаемых писем</param>
public record EmailConsumerRequest(string BoxName, int Take);