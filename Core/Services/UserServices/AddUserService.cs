using System;
using System.Collections.Generic;
using Core.DataAccess;
using Core.Entities;

namespace Core.Services.UserServices
{
    public interface IAddUserService
    {
        void Add(string username, string password, string email);
    }

    public class AddUserService : IAddUserService
    {
        private readonly RecordStoreContext _db;

        public AddUserService(RecordStoreContext db)
        {
            _db = db;
        }

        public void Add(string username, string password, string email)
        {
            var user = new User
            {
                Id = Guid.NewGuid().ToString(),
                Username = username,
                Password = password,
                Email = email,
                WalletBalance = 3000,
                CreatedAt = DateTime.Now,
                Orders = new List<Order>(),
            };

            _db.Add(user);
            _db.SaveChanges();
        }
    }
}