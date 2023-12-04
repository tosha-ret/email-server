namespace GmailProvider.Senders;

/// <summary>
/// Модель текстового письма
/// </summary>
/// <param name="Addressee">Почтовый адрес получателя</param>
/// <param name="Subject">Тема письма</param>
/// <param name="Message">Текст письма</param>
public record TextEmail(string Addressee, string Subject, string Message);