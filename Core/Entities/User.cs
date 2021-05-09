using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [Key]
        [Column(TypeName = "varchar(50)")]
        public string Id { get; set; }
        
        [Column(TypeName = "varchar(50)")]
        public string Username { get; set; }
        
        [Column(TypeName = "varchar(50)")]
        public string Password { get; set; }
        
        [Column(TypeName = "varchar(50)")]
        public string Email { get; set; }
        
        public DateTime CreatedAt { get; set; }
        
        public decimal WalletBalance { get; set; }

        public List<Order> Orders { get; set; } = new List<Order>();

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