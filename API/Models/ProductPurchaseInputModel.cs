using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace API.Models
{
    public class ProductPurchaseInputModel
    {
        [JsonPropertyName("quantity")] 
        public short Quantity { get; set; }

        // will replace this
        [JsonPropertyName("price")] 
        public decimal Price { get; set; }
        
        // will replace this
        [JsonPropertyName("spotifyId")] 
        public string SpotifyId { get; set; }
        
        //TODO should get productId from frontend, which will get the "Product" from the DB
        [JsonPropertyName("productId")]
        public string ProductId { get; set; }
    }
}

