using System.IO.Abstractions;
using EmailServer.Application;
using EmailServer.Application.PekMetering;
using GmailProvider.Extensions;
using GmailProvider.Senders;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddSingleton<IFileSystem>(new FileSystem())
    .AddApplicationLayer()
    .AddGmailProviderLayer(builder.Configuration)
    .AddEndpointsApiExplorer()
    .AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "EmailApi", Version = "v1" });
    });

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "EmailApi v1");
});

app.MapGet("/", () => "Hello World!")
    .WithName("GetHelloWorld");

app.MapGet("/authorize", () => "Удача!");

app.MapGet("/send-test", ([FromServices] ISender<TextEmail> sender, CancellationToken token) => sender.SendAsync(
    new TextEmail("tosha_retivykh@mail.ru", "test from my api5", "тестовый текст5"), token));

//app.MapPost("/send-pek-metering", ([FromServices] ISenderMeteringToPek sender, [FromBody] Metering metering, CancellationToken token) => sender.SendAsync(metering, token));

// app.MapGet("/get-test", ([FromServices] IEmailSubjectConsumer consumer, CancellationToken token) => consumer.GetEmailsAsync(token));

app.Run();