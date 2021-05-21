using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Integrations.Spotify.Objects;

namespace Core.Entities
{
    public class CartItem
    {
        [Key]
        [Column(TypeName = "varchar(50)")]
        public string Id { get; set; }
        
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string CustomerId { get; set; }
        
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string ProductId { get; set; }
        
        [Required]
        public short Quantity { get; set; }
        
        public Product Product { get; set; }
        
        public Album Album { get; set; }
    }
}