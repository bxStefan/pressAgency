using pressAgency.Domain.Repository;
using pressAgency.Domain.Repository.Interfaces;
using pressAgency.Infrastructure;
using pressAgency.Infrastructure.Interfaces;
using pressAgency.Middlewares;
using pressAgency.Services;
using pressAgency.Services.Interfaces;

namespace pressAgency.Extensions
{
    public static class ApplicationServicesExtension
    {
        public static void ConfigureApplicationServices(this IServiceCollection services)
        {
            // Middlewares
            services.AddTransient<ExceptionMiddleware>();
            services.AddScoped<BasicAuthMiddleware>();

            // Repositories
            services.AddScoped<IPostsRepository, PostsRepository>();
            services.AddScoped<IAuthorsRepository, AuthorsRepository>();
            services.AddScoped<IPostLockRepository, PostsLocksRepository>();

            // Services
            services.AddScoped<IPostsServices, PostsServices>();
            services.AddScoped<IAuthorsServices, AuthorsServices>();

            // Infrastructure
            services.AddScoped<IHttpUserContext, HttpUserContext>();
        }
    }
}
