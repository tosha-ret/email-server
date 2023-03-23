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

app.MapGet("/get-token", ([FromServices] Auth auth) => auth.CreateToken());

app.MapGet("/send-test", ([FromServices] Sender sender) => sender.Send(
    new TextEmail("tosha_retivykh@mail.ru", "test from my api", "success")));

app.Run();