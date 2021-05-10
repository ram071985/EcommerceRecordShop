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
        
        [Column(TypeName = "varchar(50)")]
        public string SpotifyId { get; set; }
        
        public decimal Price { get; set; }
    }
}