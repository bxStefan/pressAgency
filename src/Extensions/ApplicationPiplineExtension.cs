using pressAgency.Middlewares;
using Scalar.AspNetCore;

namespace pressAgency.Extensions
{
    public static class ApplicationPiplineExtension
    {
        public static void ConfigureHttpPipline(this WebApplication app)
        {
            app.ApplyMigrations();

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

            app.UseCors("CORS");

            app.MapControllers();
        }
    }
}
