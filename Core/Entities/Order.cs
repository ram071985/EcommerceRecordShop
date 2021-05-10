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
        
        [Column(TypeName = "varchar(50)")]
        public string UserId { get; set; }
        
        public DateTime PurchaseDate { get; set; } = DateTime.Now;
        
        public DateTime ShippingDate { get; set; } = DateTime.Now.AddDays(3);
        
        public DateTime CanReturnBy { get; set; } = DateTime.Now.AddDays(30);
        public List<CartItem> CartItems { get; set; } = new List<CartItem>();

        public decimal OrderTotalPrice
        {
            get
            {
                decimal totalPrice = 0;
                CartItems.ForEach(distinctAlbum => totalPrice += distinctAlbum.PurchasePrice * distinctAlbum.Quantity);
                return totalPrice;
            }
        }
    }
}