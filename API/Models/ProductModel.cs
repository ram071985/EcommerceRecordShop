using Core.Entities;
using Integrations.Spotify.Objects;

namespace API.Models
{
    public class ProductModel
    {
        public decimal Price { get; set; }
        public Album Album { get; set; }
    }
}
