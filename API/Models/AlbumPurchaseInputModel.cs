using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace API.Models
{
    public class AlbumPurchaseInputModel
    {
        [JsonPropertyName("quantity")] 
        public short Quantity { get; set; }

        [JsonPropertyName("price")] 
        public decimal Price { get; set; }
        
        [JsonPropertyName("spotifyId")] 
        public string SpotifyId { get; set; }
    }

    public class PurchaseInputModel
    {
        [JsonPropertyName("purchasedAlbumsInput")] 
        public List<AlbumPurchaseInputModel> Albums { get; set; }
        
        [JsonPropertyName("userId")] 
        public string UserId { get; set; }
    }
}

