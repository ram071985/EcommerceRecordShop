using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class Product
    {
        public Product()
        {
        }
        
        [Key]
        [Column(TypeName = "varchar(50)")]
        public string Id { get; set; }
        
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string SpotifyId { get; set; }
        
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Genre { get; set; }
        
        [Required]
        [Column(TypeName = "decimal(25,8)")]
        public decimal Price { get; set; }
    }
}