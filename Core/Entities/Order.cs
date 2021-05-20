using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class Order
    {
        public Order()
        {
        }
        
        [Key]
        [Column(TypeName = "varchar(50)")]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string CustomerId { get; set; }
        
        [Required]
        public DateTime PurchaseDate { get; set; } = DateTime.Now;
        
        [Required]
        public DateTime ShippingDate { get; set; } = DateTime.Now.AddDays(3);
        
        [Required]
        public DateTime CanReturnBy { get; set; } = DateTime.Now.AddDays(30);
        
        public decimal OrderTotalPrice
        {
            get
            {
                decimal totalPrice = 0;
                CartItems.ForEach(distinctAlbum => totalPrice += distinctAlbum.Product.Price * distinctAlbum.Quantity);
                return totalPrice;
            }
        }
        public List<CartItem> CartItems { get; set; } = new List<CartItem>();

    }
}