using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class Order
    {
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string UserId { get; set; }

        [Required] 
        public DateTime PurchaseDate { get; set; } = DateTime.Now;

        [Required] 
        public DateTime ShippingDate { get; set; } = DateTime.Now.AddDays(3);

        [Required] 
        public DateTime CanReturnBy { get; set; } = DateTime.Now.AddDays(30);

        [Required]
        public decimal TotalPrice
        {
            get
            {
                decimal totalPrice = 0;
                Products.ForEach(product => totalPrice += product.Price);
                return totalPrice;
            }
        }
        [Required] 
        public List<Product> Products { get; set; }
    }
}