using Core.Services.InventoryServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API
{
    public static class InterfaceConfigReid
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IAlbumInventoryService, AlbumInventoryService>();
        }
    }
}