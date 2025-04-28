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
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<ITownRepository, TownRepository>();
            services.AddScoped< IDistrictRepository, DistrictRepository>();
            services.AddScoped<IOrderItemRepository, OrderItemRepository>();
            services.AddScoped<IPaymentTypeRepository, PaymentTypeRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<ICartRepository, CartRepository>();
            services.AddScoped<ICartItemRepository, CartItemRepository>();

            return services;

        }
    }
}
