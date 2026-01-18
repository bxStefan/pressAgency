using Microsoft.EntityFrameworkCore;
using pressAgency.Domain.Context;

namespace pressAgency.Extensions
{
    public static class MigrationExtension
    {
        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();

            var dbContext = scope.ServiceProvider.GetRequiredService<PressDbContext>();

            dbContext.Database.Migrate();
        }
    }
}
