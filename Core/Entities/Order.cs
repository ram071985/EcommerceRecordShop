using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime PurchaseDate { get; set; }
        public DateTime ShippingDate { get; set; }
        public List<Album> Albums { get; set; }

        public decimal TransactionPrice
        {
            get
            {
                decimal totalPrice = 0;
                Albums.ForEach(album =>
                    totalPrice += album.PurchasePrice);

                return totalPrice;
            }
        }
    }

    public class Album
    {
        public string ArtistName { get; set; }
        public string AlbumName { get; set; }
        public decimal PurchasePrice { get; set; }
    }
}