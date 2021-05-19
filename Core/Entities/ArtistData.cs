using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Core.Entities
{
    [NotMapped]
    public class ArtistData
    {
        [JsonProperty("images")]
        public List<ArtistImageUrl> ArtistImageUrls { get; set; }
    }

    [NotMapped]
    public class ArtistImageUrl
    {
        [JsonProperty("url")]
        public string Url { get; set; }
        
    }
}