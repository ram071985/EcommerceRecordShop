using Core.Services.CartServices;
using Core.Services.OrderServices;
using Core.Services.ProductServices;
using Core.Services.SpotifyServices;
using Core.Services.UserServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API
{
    public static class InterfaceConfig
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IOrdersService, OrdersService>();
            services.AddScoped<ICartService, CartService>();
            services.AddScoped<ISpotifyApiHelper, SpotifyApiHelper>();
            services.AddScoped<ISpotifyAlbumService, SpotifyAlbumService>();
            services.AddScoped<IGetProductsService, GetProductsService>();
            services.AddScoped<IAddProductsService, AddProductsService>();
            services.AddScoped<IAddCustomerService, AddCustomerService>();
            services.AddScoped<IGetCustomerService, GetCustomerService>();
        }
    }
}