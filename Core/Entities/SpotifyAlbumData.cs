using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Core.Entities
{
    public class AlbumData
    {
        [JsonProperty("artists")]
        public List<Artist> Artists { get; set; }
        [JsonProperty("images")]
        public List<Image> Images { get; set; }
        [JsonProperty("label")]
        public string RecordLabel { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("release_date")]
        public string ReleaseDate { get; set; }
        [JsonProperty("total_tracks")]
        public int TotalTracks { get; set; }
        [JsonProperty("tracks")]
        public Tracks Tracks { get; set; }
    }
    
    public class Artist
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class Image
    {
        [JsonProperty("Url")]
        public string Url { get; set; }
    }

    public class Tracks
    {
        [JsonProperty("items")]
        public List<Item> Items { get; set; }
    }

    public class Item
    {
        [JsonProperty("artists")]
        public List<Artist> Artists { get; set; }
        [JsonProperty("explicit")]
        public bool Explicit { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("track_number")]
        public int TrackNumber { get; set; }
        [JsonProperty("duration_ms")]
        public int Duration { get; set; }
    }
}