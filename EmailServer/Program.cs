using System.IO.Abstractions;
using EmailServer.Application;
using GmailProvider;
using GmailProvider.Extensions;
using GmailProvider.Senders;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddSingleton<IFileSystem>(new FileSystem())
    .AddApplicationLayer()
    .AddGmailProviderLayer(builder.Configuration);

var app = builder.Build();

// app.UseSwagger();

app.MapGet("/", () => "Hello World!");
app.MapGet("/authorize", () => "Удача!");

app.MapGet("/send-test", ([FromServices] ISender<TextEmail> sender, CancellationToken token) => sender.SendAsync(
    new TextEmail("tosha_retivykh@mail.ru", "test from my api5", "тестовый текст5"), token));

// app.MapGet("/get-test", ([FromServices] IEmailSubjectConsumer consumer, CancellationToken token) => consumer.GetEmailsAsync(token));

app.Run();