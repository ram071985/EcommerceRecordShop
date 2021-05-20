using System;
using System.Collections.Generic;
using Core.DataAccess;
using Core.Entities;

namespace Core.Services.CustomerServices
{
    public interface IAddCustomerService
    {
        void Add(string customerName, string password, string email);
    }

    public class AddCustomerService : IAddCustomerService
    {
        private readonly RecordStoreContext _db;

        public AddCustomerService(RecordStoreContext db)
        {
            _db = db;
        }

        public void Add(string customerName, string password, string email)
        {
            var customer = new Customer
            {
                Id = Guid.NewGuid().ToString(),
                CustomerName = customerName,
                Password = password,
                Email = email,
                WalletBalance = 3000,
                CreatedAt = DateTime.Now,
                Orders = new List<Order>(),
            };

            _db.Add(customer);
            _db.SaveChanges();
        }
    }
}