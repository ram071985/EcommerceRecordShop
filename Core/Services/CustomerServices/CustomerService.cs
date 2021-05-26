using System;
using System.Collections.Generic;
using System.Linq;
using Core.DataAccess;
using Core.Entities;
using Microsoft.Extensions.Configuration;

namespace Core.Services.CustomerServices
{
    public interface ICustomerService
    {
        Customer GetCustomerById(string customerId);
        void AddCustomer(string customerName, string password, string email);
    }

    public class CustomerService : ICustomerService
    {
        private readonly RecordStoreContext _db;
        private readonly string _hardSalt;

        public CustomerService(IConfiguration configuration, RecordStoreContext db)
        {
            _hardSalt = configuration["PasswordSalt"];
            _db = db;
        }
        
        public Customer GetCustomerById(string customerId)
        {
            var customer = _db.Customers.FirstOrDefault(x => x.Id == customerId); 
            
            return customer;
        }

        public void AddCustomer(string customerName, string password, string email)
        {
            var hashedPassword = HashPassword(password);
            
            var customer = new Customer
            {
                Id = Guid.NewGuid().ToString(),
                CustomerName = customerName,
                Password = hashedPassword,
                Email = email,
                WalletBalance = 3000,
                CreatedAt = DateTime.Now,
                Orders = new List<Order>(),
            };

            _db.Add(customer);
            _db.SaveChanges();
        }

        private string HashPassword(string password)
        {
            var passwordToHash = password + _hardSalt;
            var passwordSalt = BCrypt.Net.BCrypt.GenerateSalt();
            return BCrypt.Net.BCrypt.HashPassword(passwordToHash, passwordSalt);
        }
    }
}