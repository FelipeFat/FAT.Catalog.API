using FAT.Catalog.API.Data;
using FAT.Catalog.API.Data.Repository;
using FAT.Catalog.API.Models.Interfaces;

namespace FAT.Catalog.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<CatalogContext>();
        }
    }
}