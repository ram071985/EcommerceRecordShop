using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace API.Models
{
    public class OrderInputModel
    {
        [JsonPropertyName("purchasedAlbumsInput")] 
        public List<ProductPurchaseInputModel> Albums { get; set; }
        
        [JsonPropertyName("userId")] 
        public string UserId { get; set; }
    }
}