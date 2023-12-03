using System.IO.Abstractions;
using GmailProvider;
using GmailProvider.Options;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddSingleton<IFileSystem>(new FileSystem())
    // .AddSingleton<Auth>()
    .AddSingleton<TextSender>()
    .Configure<GmailOptions>(builder.Configuration.GetSection(nameof(GmailOptions)));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/authorize", () => "Удача!");

app.MapGet("/send-test", ([FromServices] TextSender sender, CancellationToken token) => sender.SendAsync(
    new TextEmail("tosha_retivykh@mail.ru", "test from my api4", "тестовый текст4"), token));

app.Run();