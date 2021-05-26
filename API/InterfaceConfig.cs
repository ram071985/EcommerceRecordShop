using Core.DataAccess;
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
            services.AddScoped<IAdminProductsService, AdminProductsService>();
            services.AddScoped<IAdminProductSeedService, AdminProductSeedService>();
            services.AddScoped<IProductsService, ProductsService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ICartService, CartService>();
            services.AddScoped<IOrdersService, OrdersService>();
        }
    }
}