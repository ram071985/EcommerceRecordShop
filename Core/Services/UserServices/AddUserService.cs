using System;
using Core.Entities;

namespace Core.Services.UserServices
{
    public interface IAddUserService
    {
        void Add(string username, string password, string email);
    }

    public class AddUserService : IAddUserService
    {
        public void Add(string username, string password, string email)
        {
            var user = new User
            {
                Username = username,
                Password = password,
                Email = email,
                CreatedAt = DateTime.Now,
                WalletBalance = 1000
            };
            
            // TODO add user to database    
        }
    }
}