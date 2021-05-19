using Newtonsoft.Json;

namespace API.Models
{
    public class ProductInputModel
    {
        [JsonProperty("spotifyId")]
        public string SpotifyId { get; set; }
        
        [JsonProperty("genre")]
        public string Genre { get; set; }
        
        [JsonProperty("price")]
        public decimal Price { get; set; }
    }
}