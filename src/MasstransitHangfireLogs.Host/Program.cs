using Serilog;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();

builder.Host.UseSerilog(Log.Logger);

builder.Services.AddServiceCollections(builder.Configuration);

var app = builder.Build();

app.UseApplicationBuilder();
 
await app.RunAsync();