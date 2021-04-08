using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public class Order
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid UserId { get; set; }
        public DateTime PurchaseDate { get; set; } = DateTime.Now;
        public DateTime ShippingDate { get; set; } = DateTime.Now.AddDays(3);
        public DateTime CanReturnBy { get; set; } = DateTime.Now.AddDays(30);
        public List<Product> Products { get; set; }

        // public decimal TransactionPrice
        // {
        //     get
        //     {
        //         decimal totalPrice = 0;
        //         Albums.ForEach(album =>
        //             totalPrice += album.PurchasePrice);

        //         return totalPrice;
        //     }
        // }
    }

}