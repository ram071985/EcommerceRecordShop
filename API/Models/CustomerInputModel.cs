using System.Text.Json.Serialization;

namespace API.Models
{
    public class CustomerInputModel
    {
        [JsonPropertyName("customerName")] 
        public string CustomerName { get; set; }
        
        [JsonPropertyName("password")] 
        public string Password { get; set; }
        
        [JsonPropertyName("email")] 
        public string Email { get; set; }
    }
}
