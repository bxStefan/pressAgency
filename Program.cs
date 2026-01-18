using Microsoft.EntityFrameworkCore;
using pressAgency.Domain.Context;
using pressAgency.Domain.Repository;
using pressAgency.Domain.Repository.Interfaces;
using pressAgency.Infrastructure;
using pressAgency.Infrastructure.Interfaces;
using pressAgency.Middlewares;
using pressAgency.Services;
using pressAgency.Services.Interfaces;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddOpenApi();

builder.Services.AddHttpContextAccessor();

builder.Services.AddTransient<ExceptionMiddleware>();
builder.Services.AddScoped<BasicAuthMiddleware>();

builder.Services.AddScoped<IPostsRepository, PostsRepository>();
builder.Services.AddScoped<IPostsServices, PostsServices>();
builder.Services.AddScoped<IAuthorsRepository, AuthorsRepository>();
builder.Services.AddScoped<IAuthorsServices, AuthorsServices>();
builder.Services.AddScoped<IPostLockRepository, PostsLocksRepository>();

builder.Services.AddScoped<IHttpUserContext, HttpUserContext>();

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

app.UseMiddleware<BasicAuthMiddleware>();

app.UseMiddleware<ExceptionMiddleware>();

app.MapControllers();

await app.RunAsync();
