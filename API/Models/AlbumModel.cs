using System.Text.Json.Serialization;

namespace API.Models
{
    public class AlbumModel
    {
        [JsonPropertyName("id")]
        public short Id { get; set; }

        [JsonPropertyName("artistName")]
        public string ArtistName { get; set; }

        [JsonPropertyName("albumName")]
        public string AlbumName { get; set; }

        [JsonPropertyName("price")]
        public decimal Price { get; set; }
    }
}
