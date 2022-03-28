using FAT.Customers.API.Data;

namespace FAT.Customers.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<CustomerContext>();
        }
    }
}