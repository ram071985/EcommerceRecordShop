using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace API.Models
{
    public class CartItemInputModel
    {
        [JsonPropertyName("quantity")] 
        public short Quantity { get; set; }

        [JsonPropertyName("productId")]
        public string ProductId { get; set; }
    }
}

