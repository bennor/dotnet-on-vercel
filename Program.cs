var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

var app = builder.Build();

app.MapOpenApi();

app.MapGet("/", () => TypedResults.Json(new
{
  message = "Hi from .NET on Vercel",
  datetime = DateTimeOffset.UtcNow,
  dotnet = new
  {
    frameworkDescription = System.Runtime.InteropServices.RuntimeInformation.FrameworkDescription,
    runtimeVersion = Environment.Version.ToString(),
    osDescription = System.Runtime.InteropServices.RuntimeInformation.OSDescription,
    osArchitecture = System.Runtime.InteropServices.RuntimeInformation.OSArchitecture.ToString(),
    processArchitecture = System.Runtime.InteropServices.RuntimeInformation.ProcessArchitecture.ToString(),
    processorCount = Environment.ProcessorCount
  }
}));

var port = Environment.GetEnvironmentVariable("PORT") ?? "80";

app.Run($"http://0.0.0.0:{port}");