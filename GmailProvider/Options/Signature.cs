namespace GmailProvider.Options;

/// <summary>
/// Данные подписи письма
/// </summary>
/// <param name="Name"></param>
/// <param name="Phone"></param>
/// <param name="Email"></param>
public sealed record Signature(string Name, string Phone, string Email);