using System.Collections.Generic;
using Newtonsoft.Json;

namespace Integrations.Spotify.Objects
{
    public class SearchResponse
    {
        [JsonProperty("albums")]
        public SearchItems SearchItems { get; set; }
    }

    public class SearchItems
    {
        [JsonProperty("items")]
        public List<SearchAlbumItem> AlbumItems { get; set; }
    }

    public class SearchAlbumItem
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("images")]
        public List<Image> Images { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("total_tracks")]
        public int TotalTracks { get; set; }
        [JsonProperty("artists")]
        public List<ArtistData> Artists { get; set; }
    }

}