using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

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
        
        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Username { get; set; }
        
        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Password { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string Email { get; set; }
        
        [Required]
        public DateTime CreatedAt { get; set; }
        
        [Required]
        [Column(TypeName = "decimal(25,8)")]
        public decimal WalletBalance { get; set; }

        public List<Order> Orders { get; set; } 

        public decimal TotalSpent
        {
            get
            {
                decimal totalSpent = 0;
                Orders.ForEach(order => totalSpent += order.OrderTotalPrice);
                return totalSpent;
            }
        }
    }
}