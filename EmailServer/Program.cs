using System.IO.Abstractions;
using GmailProvider;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddSingleton<IFileSystem>(new FileSystem())
    .AddSingleton<Auth>()
    .AddSingleton<Sender>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/authorize", () => "Удача!");

app.MapGet("/send-test", ([FromServices] Sender sender, CancellationToken token) => sender.SendAsync(
    new TextEmail("tosha_retivykh@mail.ru", "test from my api", "тестовый текст"), token));

app.Run();