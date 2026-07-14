var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

// HTTPS redirection and HSTS are intentionally omitted: Vercel terminates TLS
// at the edge and forwards plain HTTP to the container on $PORT.

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

var port = Environment.GetEnvironmentVariable("PORT") ?? "80";

app.Run($"http://0.0.0.0:{port}");
