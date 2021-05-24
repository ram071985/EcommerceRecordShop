using System;
using System.Collections.Generic;
using System.Linq;
using Core.DataAccess;
using Core.Entities;

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

        public CustomerService(RecordStoreContext db)
        {
            _db = db;
        }
        
        public Customer GetCustomerById(string customerId)
        {
            var customer = _db.Customers.FirstOrDefault(x => x.Id == customerId); 
            
            return customer;
        }

        public void AddCustomer(string customerName, string password, string email)
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