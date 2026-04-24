using System.IO.Abstractions;
using EmailServer;
using EmailServer.Application;
using EmailServer.Application.Common;
using EmailServer.Application.Common.Models;
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
		{
			Title = "EmailApi",
			Version = "v1"
		});
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

app.MapGet("/send-test",
	([FromServices] ISender<TextEmail> sender, CancellationToken token) =>
		sender.SendAsync(new("tosha_retivykh@mail.ru", "test from my api5", "тестовый текст5"), token));

app.MapGet("/pek-metering/last", ([FromServices] IMeteringService service, CancellationToken token) =>
	service.GetLastAsync(token));

app.MapPost("/pek-metering/query", (
		[FromServices] IMeteringService service,
		[FromBody] MeteringFilterView filter,
		CancellationToken token) =>
	service.GetByFilterAsync(filter, token));

app.MapPost("/pek-metering", (
	[FromServices] IMeteringService service,
	[FromBody] MeteringView meteringView,
	CancellationToken token) => service.SaveAsync(meteringView, token));

app.MapPost("/pek-metering/send", (
	[FromServices] IMeteringSender sender,
	[FromBody] MeteringView meteringView,
	CancellationToken token) => sender.SendAsync(meteringView, token));

// app.MapGet("/get-test", ([FromServices] IEmailSubjectConsumer consumer, CancellationToken token) => consumer.GetEmailsAsync(token));

app.Run();