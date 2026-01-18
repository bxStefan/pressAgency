namespace pressAgency.Extensions
{
    public static class CommonServicesExtension
    {
        public static void ConfigureCommonServices(this IServiceCollection services)
        {
            services.AddControllers();

            services.AddOpenApi();

            services.AddHttpContextAccessor();
        }
    }
}
