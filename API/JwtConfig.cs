//using System.Text;
//using Core.Services.AuthenticationServices;
//using Microsoft.AspNetCore.Authentication.JwtBearer;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.IdentityModel.Tokens;

//namespace API
//{
//    public static class JwtConfig
//    {
//        public static void Configure(IServiceCollection services, IConfiguration configuration)
//        {
//            var key = configuration["JwtKey"];

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