using ECommerce.DataAccess.Abstract;
using ECommerce.DataAccess.Concrete;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.DataAccess.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDataAccessRegistration(this IServiceCollection services)
        {
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IColourRepository, ColourRepository>();
            services.AddScoped<IOrdersRepository, OrderRepository>();
            services.AddScoped<IParentCategoryRepository, ParentCategoryRepository>();
            services.AddScoped<IProductColourRepository, ProductColourRepository>();
            services.AddScoped<IProductImagesRepository, ProductImagesRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductSizeRepository, ProductSizeRepository>();
            services.AddScoped<ISizeRepository, SizeRepository>();
            services.AddScoped<ISizeTypeRepository, SizeTypeRepository>();

            return services;

        }
    }
}
