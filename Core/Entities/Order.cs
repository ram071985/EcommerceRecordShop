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
<<<<<<< HEAD

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string UserId { get; set; }

        [Required] 
        public DateTime PurchaseDate { get; set; } = DateTime.Now;

        [Required] 
        public DateTime ShippingDate { get; set; } = DateTime.Now.AddDays(3);
=======
        
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
        public List<Product> Products { get; set; }
>>>>>>> f1981c69922911dddca4f3da6f78c7fc9e311e2f

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