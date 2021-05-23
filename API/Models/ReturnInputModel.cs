using Newtonsoft.Json;

namespace API.Models
{
    public class ReturnInputModel
    {
        [JsonProperty("orderId")]
        public string OrderId { get; init; }
        
        [JsonProperty("orderItemId")]
        public string OrderItemId { get; init; }
        
        [JsonProperty("returnCount")] 
        public int ReturnCount { get; init; }
    }
}