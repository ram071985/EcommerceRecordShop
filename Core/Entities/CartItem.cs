using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class CartItem
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public short Quantity { get; set; }
        public string ProductId { get; set; }
        
        public Product Product { get; set; }
        public Album Album { get; set; }
    }
}