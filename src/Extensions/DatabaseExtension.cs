using Microsoft.EntityFrameworkCore;
using pressAgency.Domain.Context;

namespace pressAgency.Extensions
{
    public static class DatabaseExtension
    {
        public static void ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Postgres");

            services.AddDbContext<PressDbContext>(options => 
            {
                options.UseNpgsql(connectionString);
            });
        }
    }
}
