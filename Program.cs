using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using pressAgency.Domain.Context;
using pressAgency.Middlewares;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddOpenApi();

builder.Services.AddTransient<ExceptionMiddleware>();

builder.Services.AddDbContext<PressDbContext>(options => {
    options.UseNpgsql(builder.Configuration.GetConnectionString("Postgres"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(options =>
    {
        options.Title = "pressAPI";
        options.WithClassicLayout();
        options.WithTheme(ScalarTheme.Default);
        options.DefaultOpenAllTags = true;
    });
}

app.UseHttpsRedirection();

app.UseMiddleware<ExceptionHandlerMiddleware>();

app.UseAuthorization();

app.MapControllers();

await app.RunAsync();
