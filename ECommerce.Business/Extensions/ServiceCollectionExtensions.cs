using ECommerce.Business.Abstract;
using ECommerce.Business.Concrete.Managers;
using ECommerce.DataAccess.Abstract;
using ECommerce.DataAccess.Concrete;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Business.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBusinessRegistration(this IServiceCollection services)
        {
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IColourService, ColourService>();
            services.AddScoped<IOrdersService, OrdersService>();
            services.AddScoped<IParentCategoryService, ParentCategoryService>();
            services.AddScoped<IProductColourService, ProductColourService>();
            services.AddScoped<IProductImageService, ProductImageService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductSizeService, ProductSizeService>();
            services.AddScoped<ISizeService, SizeService>();
            services.AddScoped<ISizeTypeService, SizeTypeService>();
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<ICityService, CityService>();
            services.AddScoped<ITownService, TownService>();
            services.AddScoped<IDistrictService, DistrictService>();

            return services;
        }
    }
}
