using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Integrations.Spotify.Objects;

namespace Core.Entities
{
    public class Product
    {
        [Key]
        [Column(TypeName = "varchar(50)")]
        public string Id { get; init; }
        
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string SpotifyId { get; init; }
        
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Genre { get; init; }
        
        [Required]
        [Column(TypeName = "decimal(25,8)")]
        public decimal Price { get; init; }

        [Required]
        public int QuantityAvailable { get; set; }
        
        [Required]
        public DateTime DateAdded { get; init; }
        
        [NotMapped]
        public Album Album { get; set; }
    }
}
