using System;
using Integrations.Spotify.Objects;

namespace API.Models
{
    public class ProductModel
    {
        public string Id { get; init; }
        public int QuantityAvailable { get; init; }
        public DateTime DateAdded { get; init; }
        public decimal Price { get; init; }
        public Album Album { get; init; }
    }
}
