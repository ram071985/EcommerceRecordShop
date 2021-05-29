using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Core.DataAccess;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Bcrypt = BCrypt.Net.BCrypt;

namespace Core.Services.AuthenticationServices
{
    public interface IGenerateJwtToken
    {
        string Authenticate(string username, string password);
    }

    public class GenerateJwtToken : IGenerateJwtToken
    {
        private readonly string _key;
        private readonly string _hardSalt;
        private readonly RecordStoreContext _db;

        static GenerateJwtToken()
        {
            
        }
        public GenerateJwtToken(
            IConfiguration configuration,
            RecordStoreContext db)
        {
            _key = configuration["JwtKey"];
            _hardSalt = configuration["PasswordSalt"];
            _db = db;
        }

        public string Authenticate(string username, string password)
        {
            if (!AuthenticateCustomer(username, password)) return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(_key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] {new(ClaimTypes.Name, username)}),
                Expires = DateTime.Now.AddDays(30),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        private bool AuthenticateCustomer(string username, string password)
        {
            var customer = _db.Customers
                .FirstOrDefault(x => x.CustomerName == username);

            if (customer == null) return false;
            
            if (!customer.IsActive)
                throw new Exception("customer is not active");

            return Bcrypt.Verify(password + _hardSalt, customer.Password);
        }
    }
}
