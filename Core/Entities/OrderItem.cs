using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class OrderItem
    {
        [Key]
        [Column(TypeName = "varchar(50)")]
        public string Id { get; init; }
        
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string ProductId { get; init; }
        
        [Required]
        public short Quantity { get; init; }
        
        public Product Product { get; set; }
    }
}