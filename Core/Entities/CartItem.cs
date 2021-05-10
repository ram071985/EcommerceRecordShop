using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class CartItem
    {
        [Key]
        public int Id { get; set; }
        public short Quantity { get; set; }
        public decimal PurchasePrice { get; set; }
        public string SpotifyId { get; set; }
        public string UserId { get; set; }
    }
}