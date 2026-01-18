using pressAgency.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Services registration
builder.Services.ConfigureCommonServices();

builder.Services.ConfigureApplicationServices();

builder.Services.ConfigureDatabase(builder.Configuration);

builder.Services.ConfigureCors();

// HTTP Request pipeline configuration
var app = builder.Build();

app.ConfigureHttpPipline();

await app.RunAsync();
