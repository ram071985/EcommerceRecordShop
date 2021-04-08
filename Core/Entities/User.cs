using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public class User
    {
        public User()
        {
        }

        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime? CreatedAt { get; set; }
        public decimal WalletBalance { get; set; }
        public List<Order> Orders {get;set;}
    }
}