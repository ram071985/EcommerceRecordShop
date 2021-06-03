using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Integrations.Spotify.Objects
{
    [NotMapped]
    public class ArtistsData
    {
        [JsonProperty("artists")]
        public List<ArtistData> ArtistsList { get; set; }
    }
    
    [NotMapped]
    public class ArtistData
    {
        [JsonProperty("images")]
        public List<ArtistImageUrl> ArtistImageUrls { get; set; }
        
        [JsonProperty("genres")]
        public List<string> Genres { get; set; }
        
        [JsonProperty("name")] 
        public string Name { get; set; }
    }

    [NotMapped]
    public class ArtistImageUrl
    {
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}