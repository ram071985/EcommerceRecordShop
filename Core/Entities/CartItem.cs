using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class CartItem
    {
        [Key]
        [Column(TypeName = "varchar(50)")]
        public string Id { get; set; }
        
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string UserId { get; set; }
        
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string ProductId { get; set; }
        
        [Required]
        public short Quantity { get; set; }
        
        public Product Product { get; set; }
        
        public Album Album { get; set; }
    }
}