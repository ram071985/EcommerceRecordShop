using Core.Services.OrderServices;
using Core.Services.UserServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API
{
    public static class InterfaceConfigBrian
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IAddUserService, AddUserService>();
            services.AddScoped<IPlaceOrderService, PlaceOrderService>();
        }
    }
}