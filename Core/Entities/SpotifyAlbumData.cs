using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Core.Entities
{
    public class SpotifyAlbumData
    {

        [JsonProperty("items")] public List<Track> Items { get; set; }

        [JsonProperty("total")] public long Total { get; set; }
    }

    public partial class Track
    {
        [JsonProperty("artists")] public List<Artist> Artists { get; set; }

        [JsonProperty("disc_number")] public long DiscNumber { get; set; }

        [JsonProperty("duration_ms")] public long DurationMs { get; set; }

        [JsonProperty("explicit")] public bool Explicit { get; set; }

        [JsonProperty("href")] public Uri Href { get; set; }

        [JsonProperty("id")] public string Id { get; set; }

        [JsonProperty("is_local")] public bool IsLocal { get; set; }

        [JsonProperty("name")] public string Name { get; set; }

        [JsonProperty("preview_url")] public Uri PreviewUrl { get; set; }

        [JsonProperty("track_number")] public long TrackNumber { get; set; }

        [JsonProperty("type")] public string Type { get; set; }

        [JsonProperty("uri")] public string Uri { get; set; }
    }

    public partial class Artist
    {
        [JsonProperty("id")] public string Id { get; set; }

        [JsonProperty("name")] public string Name { get; set; }

        [JsonProperty("type")] public string Type { get; set; }

        [JsonProperty("uri")] public string Uri { get; set; }
    }
}