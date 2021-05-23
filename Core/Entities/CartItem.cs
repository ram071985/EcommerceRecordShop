using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Integrations.Spotify.Objects;

namespace Core.Entities
{
    public class CartItem
    {
        [Key]
        [Column(TypeName = "varchar(50)")]
        public string Id { get; init; }
        
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string CustomerId { get; init; }
        
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string ProductId { get; init; }
        
        [Required]
        public short Quantity { get; set; }
        
        public Product Product { get; set; }
        
        [NotMapped]
        public Album Album { get; set; }
    }
}