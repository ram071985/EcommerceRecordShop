using System.Text.Json.Serialization;

namespace API.Models
{
    public class CartItemInputModel
    {
        [JsonPropertyName("productId")]
        public string ProductId { get; set; }
        
        [JsonPropertyName("quantity")] 
        public short Quantity { get; set; }
    }
}

