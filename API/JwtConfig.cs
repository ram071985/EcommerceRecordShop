<<<<<<< HEAD
//using System.Text;
//using Core.Services.AuthenticationServices;
//using Microsoft.AspNetCore.Authentication.JwtBearer;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.IdentityModel.Tokens;
=======
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Core.DataAccess;
using Core.Services.AuthenticationServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
>>>>>>> 4104fb9 (add Bcrypt and hardcoded salt)

//namespace API
//{
//    public static class JwtConfig
//    {
//        public static void Configure(IServiceCollection services, IConfiguration configuration)
//        {
//            var key = configuration["JwtKey"];

<<<<<<< HEAD
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddScoped<IGenerateJwtToken, GenerateJwtToken>();
        }
    }
}
=======
//            services.AddAuthentication(x =>
//            {
//                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//            }).AddJwtBearer(x =>
//            {
//                x.RequireHttpsMetadata = false;
//                x.SaveToken = true;
//                x.TokenValidationParameters = new TokenValidationParameters
//                {
//                    ValidateIssuerSigningKey = true,
//                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
//                    ValidateIssuer = false,
//                    ValidateAudience = false
//                };
//            });

//            // TODO will need to pass in an instance of a database authentication class 
//            services.AddSingleton<IGenerateJwtToken>(
//                new GenerateJwtToken(key));
//        }
//    }
//}
>>>>>>> nav-product-test
