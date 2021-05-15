using System.Collections.Generic;
using Newtonsoft.Json;

namespace Core.Entities
{
    public class ArtistData
    {
        [JsonProperty("images")]
        public List<ArtistImageUrl> ArtistImageUrls { get; set; }
    }

    public class ArtistImageUrl
    {
        [JsonProperty("url")]
        public string Url { get; set; }
        
    }
}