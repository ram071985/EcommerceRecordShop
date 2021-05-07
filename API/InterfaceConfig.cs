using Core.DataAccess;
using Core.Services.OrderServices;
using Core.Services.ProductServices;
using Core.Services.SpotifyServices;
using Core.Services.UserServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API
{
    public static class InterfaceConfig
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IAddUserService, AddUserService>();
            services.AddScoped<IPlaceOrderService, PlaceOrderService>();
            services.AddScoped<ISpotifyApiHelper, SpotifyApiHelper>();
            services.AddScoped<ISpotifyAlbumService, SpotifyAlbumService>();
            services.AddScoped<IGetProductsService, GetProductsService>();
            services.AddDbContext<OrderContext>(options =>
            {
                options.UseSqlServer(configuration["ConnectionStrings:Default"]);
            });
        }
    }
}