using System;
using System.Collections.Generic;
using System.Linq;
using Core.DataAccess;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Bcrypt = BCrypt.Net.BCrypt;

namespace Core.Services.CustomerServices
{
    public interface ICustomerService
    {
        Customer GetCustomerById(string customerId);
        void AddCustomer(string customerName, string password, string email);
        void DeactivateCustomer(string customerId);
        void ActivateCustomer(string customerId);
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
            var dbCustomer = _db.Customers.FirstOrDefault(x => x.CustomerName == customerName);

            if (dbCustomer != null)
                throw new Exception("already a customer with this customername");

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
                IsActive = true
            };

            _db.Add(customer);
            _db.SaveChanges();
        }

        public void DeactivateCustomer(string customerId)
        {
            var customer = _db.Customers.Where(x => x.Id == customerId)
                .Include(x => x.CartItems)
                .FirstOrDefault();

            if (customer == null)
                throw new Exception("customer with this id is null");

            if (customer.IsActive) return;

            customer.IsActive = false;

            if (customer.CartItems is {Count: > 0})
                _db.RemoveRange(customer.CartItems);

            _db.Update(customer);
            _db.SaveChanges();
        }

        public void ActivateCustomer(string customerId)
        {
            var customer = _db.Customers.FirstOrDefault(x => x.Id == customerId);

            if (customer == null)
                throw new Exception("customer with this id is null");

            if (!customer.IsActive) return;

            customer.IsActive = true;

            _db.Update(customer);
            _db.SaveChanges();
        }

        private string HashPassword(string password)
        {
            var passwordToHash = password + _hardSalt;
            var passwordSalt = BCrypt.Net.BCrypt.GenerateSalt();
            return Bcrypt.HashPassword(passwordToHash, passwordSalt);
        }
    }
}