using System;
using Integrations.Spotify.Objects;

namespace API.Models
{
    public class ProductModel
    {
        public string Id { get; set; }
        public int QuantityAvailable { get; set; }
        public DateTime DateAdded { get; set; }
        public decimal Price { get; set; }
        public Album Album { get; set; }
    }
}
