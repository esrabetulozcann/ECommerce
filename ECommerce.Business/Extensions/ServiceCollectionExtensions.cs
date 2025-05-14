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
            services.AddScoped<IColourService, ColourService>();
            services.AddScoped<IOrdersService, OrdersService>();
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
            services.AddScoped<IOrderItemService, OrderItemService>();
            services.AddScoped<IPaymentTypeService, PaymentTypeService>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<ICartService, CartService>();
            services.AddScoped<ICartItemService, CartItemService>();
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IInvoiceService, InvoiceService>();
            services.AddScoped<IInvoiceDetailService, InvoiceDetailService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IAuthService, AuthService>();

         

            return services;
        }
    }
}
