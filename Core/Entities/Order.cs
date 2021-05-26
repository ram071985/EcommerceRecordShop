using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class Order
    {
        [Key]
        [Column(TypeName = "varchar(50)")]
        public string Id { get; init; } 
        
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string CustomerId { get; init; }
        
        [Required]
        public DateTime PurchaseDate { get; init; } 
        
        [Required]
        public DateTime ShippingDate { get; init; }
        
        [Required]
        public DateTime CanReturnBy { get; init; }

        [NotMapped] 
        public decimal TotalOrderPrice { get; set; }
        
        public List<OrderItem> OrderItems { get; init; } 
    }
}