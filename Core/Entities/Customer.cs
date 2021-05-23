using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Core.Entities
{
    public class Customer
    {
        [Key]
        [Column(TypeName = "varchar(50)")]
        public string Id { get; init; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string CustomerName { get; init; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Password { get; init; }

        [Required] 
        [MaxLength(100)] 
        public string Email { get; init; }

        [Required] 
        public DateTime CreatedAt { get; init; }

        [Required]
        [Column(TypeName = "decimal(25,8)")]
        public decimal WalletBalance { get; set; }

        public decimal TotalSpent =>  Orders?.Sum(order => order.TotalOrderPrice) ?? 0; 
        
        public List<Order> Orders { get; set; }

        public List<CartItem> CartItems { get; set; }
    }
}