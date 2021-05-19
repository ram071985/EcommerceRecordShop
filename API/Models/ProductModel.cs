using Core.Entities;

namespace API.Models
{
    public class ProductModel
    {
        public decimal Price { get; set; }
        public Album Album { get; set; }
    }
}
