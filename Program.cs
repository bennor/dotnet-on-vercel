var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

var app = builder.Build();

app.MapOpenApi();

app.MapGet("/", () => TypedResults.Json(new
{
  message = "Hi from .NET on Vercel",
  datetime = DateTimeOffset.UtcNow
}));

var port = Environment.GetEnvironmentVariable("PORT") ?? "80";

app.Run($"http://0.0.0.0:{port}");