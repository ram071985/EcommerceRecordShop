using System.Text.Json.Serialization;

namespace API.Models
{
    public class AlbumPurchaseInputModel
    {
        [JsonPropertyName("quantity")] 
        public short Quantity { get; set; }

        [JsonPropertyName("artistName")] 
        public string ArtistName { get; set; }

        [JsonPropertyName("albumName")] 
        public string AlbumName { get; set; }

        [JsonPropertyName("purchasePrice")] 
        public decimal PurchasePrice { get; set; }
        
        [JsonPropertyName("userId")] 
        public short UserId { get; set; }
    }
}