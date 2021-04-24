using Core.DataAccess;
using Core.Services.InventoryServices;
using Core.Services.OrderServices;
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
            services.AddScoped<IAlbumInventoryService, AlbumInventoryService>();
            services.AddScoped<IAddUserService, AddUserService>();
            services.AddScoped<IPlaceOrderService, PlaceOrderService>();
            services.AddScoped<ISpotifyApiHelper, SpotifyApiHelper>();
            services.AddScoped<ISpotifyAlbumService, SpotifyAlbumService>();
            services.AddDbContext<OrderContext>(options =>
            {
                options.UseSqlServer(configuration["ConnectionStrings:Default"]);
            });
        }
    }
}