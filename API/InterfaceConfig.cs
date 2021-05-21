using Core.Services.CartServices;
using Core.Services.CustomerServices;
using Core.Services.OrderServices;
using Core.Services.ProductServices;
using Integrations.Spotify.Services;
using Microsoft.Extensions.DependencyInjection;

namespace API
{
    public static class InterfaceConfig
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddScoped<ISpotifyApiHelper, SpotifyApiHelper>();
            services.AddScoped<ISpotifyAlbumService, SpotifyAlbumService>();
            services.AddScoped<IAddProductsService, AddProductsService>();
            services.AddScoped<IGetProductsService, GetProductsService>();
            services.AddScoped<IAddCustomerService, AddCustomerService>();
            services.AddScoped<IGetCustomerService, GetCustomerService>();
            services.AddScoped<ICartService, CartService>();
            services.AddScoped<IOrdersService, OrdersService>();
        }
    }
}