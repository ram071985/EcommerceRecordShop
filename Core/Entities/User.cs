using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public class User
    {
        public User()
        {
        }

        public User(string username, string password, string email)
        {
            Id = Guid.NewGuid().ToString();
            Username = username;
            Password = password;
            Email = email;
            WalletBalance = 3000;
            CreatedAt = DateTime.Now;
            Orders = new List<Order>();
        }

        public string Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime? CreatedAt { get; set; }
        public decimal WalletBalance { get; set; }
        public List<Order> Orders { get; set; }

        public decimal TotalSpent
        {
            get
            {
                decimal totalSpent = 0;
                Orders.ForEach(order => totalSpent += order.TotalPrice);
                return totalSpent;
            }
        }
    }
}