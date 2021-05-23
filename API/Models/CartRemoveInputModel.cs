using System.Text.Json.Serialization;

namespace API.Models
{
    public class CartRemoveInputModel
    {
        [JsonPropertyName("cartItemId")]
        public string CartItemId { get; set; }
        
        [JsonPropertyName("quantity")] 
        public short Quantity { get; set; }
    }
}