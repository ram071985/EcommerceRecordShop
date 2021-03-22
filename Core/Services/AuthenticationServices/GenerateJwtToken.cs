using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Core.Services.AuthenticationServices
{
    public interface IGenerateJwtToken
    {
        string Authenticate(string username, string password);
    }

    public class GenerateJwtToken : IGenerateJwtToken
    {
        private readonly string _key;

        // TODO temp... this should be authenticated against the database
        private readonly Dictionary<string, string> _users = new Dictionary<string, string>
        {
            {"user1", "password1"},
            {"user2", "password2"}
        };

        public GenerateJwtToken(string key)
        {
            _key = key;
        }

        public string Authenticate(string username, string password)
        {
            // TODO this is where the db should be called => _dataAccess.GetUserAuth(username, password);
            if (!_users.Any(user => user.Key == username && user.Value == password))
                return null;
            
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(_key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, username)
                }),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            
            var token = tokenHandler.CreateToken(tokenDescriptor);
            
            return tokenHandler.WriteToken(token);
        }
    }
}