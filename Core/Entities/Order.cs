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
        public string Id { get; set; } 
        
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string CustomerId { get; set; }
        
        [Required]
        public DateTime PurchaseDate { get; set; } 
        
        [Required]
        public DateTime ShippingDate { get; set; }
        
        [Required]
        public DateTime CanReturnBy { get; set; }
        
        [NotMapped]
        public decimal OrderTotalPrice
        {
            get
            {
                if (CartItems == null) return 0;
                decimal totalPrice = 0;
                CartItems.ForEach(distinctAlbum => totalPrice += distinctAlbum.Product.Price * distinctAlbum.Quantity);
                return totalPrice;
            }
        }
        
        // TODO should this be a new table? Should the cart table have a column => (bool) Purchased?
        public List<CartItem> CartItems { get; set; } 

    }
}