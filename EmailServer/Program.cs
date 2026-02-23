using System.IO.Abstractions;
using EmailServer;
using EmailServer.Application;
using EmailServer.Application.PekMetering;
using EmailServer.Postgres.Infrastructure.Extensions;
using GmailProvider.Extensions;
using GmailProvider.Senders;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddSingleton<IFileSystem>(new FileSystem())
	.AddSingleton<ILogger, Logger>()
	.AddHttpContextAccessor()
    .AddApplicationLayer()
    .AddGmailProviderLayer(builder.Configuration)
	.AddPostgresDataAccessLayerServices(builder.Configuration)
    .AddEndpointsApiExplorer()
    .AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new()
			{ Title = "EmailApi", Version = "v1" });
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

app.MapGet("/last-pek-metering", ([FromServices] IMeteringService service, CancellationToken token) =>
	service.GetLastAsync(Guid.Parse("c0922377-d913-4533-b32c-8c9ef46a45bc"), token));

app.MapPost("/send-pek-metering", ([FromServices] IMeteringSender sender, [FromBody] MeteringView meteringView, CancellationToken token) => sender.SendAsync(meteringView, token));

// app.MapGet("/get-test", ([FromServices] IEmailSubjectConsumer consumer, CancellationToken token) => consumer.GetEmailsAsync(token));

app.Run();