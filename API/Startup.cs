using API.Middleware;
using Core.DataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace API
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<RecordStoreContext>(options =>
                options.UseSqlServer(_configuration["ConnectionStrings:Default"]));
                
            services.AddControllers();
            services.AddSpaStaticFiles(config => config.RootPath = "client/build");

<<<<<<< HEAD
            InterfaceConfig.Configure(services);
            JwtConfig.Configure(services, _configuration);
<<<<<<< HEAD

            services.AddDbContext<RecordStoreContext>(options =>
                options.UseSqlServer(_configuration["ConnectionStrings:Default"]));
=======
            InterfaceConfig.Configure(services, _configuration);
            //JwtConfig.Configure(services, _configuration);
>>>>>>> nav-product-test
=======
>>>>>>> 4104fb9 (add Bcrypt and hardcoded salt)
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseMiddleware<ExceptionMiddleware>();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => endpoints.MapControllers());

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "client";
                
                if (env.IsDevelopment())
                    spa.UseReactDevelopmentServer(npmScript: "start");
            });
        }
    }
}