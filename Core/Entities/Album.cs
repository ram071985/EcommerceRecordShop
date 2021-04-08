using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public class Album
    {
        public short Id { get; set; }
        public string SpotifyId { get; set; }
        public string Name { get; set; }
        public string ArtistName { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string ImageUrl { get; set; }
        public string RecordLabel { get; set; }
        public int TotalTracks { get; set; }
        public string Description { get; set; }
        public List<string> Collaborators { get; set; }
        public List<Track> Tracks { get; set; }
    }

    public class Track
    {
        public string Name { get; set; }
        public int TrackNumber { get; set; }
        public int Duration { get; set; }
        public bool Explicit { get; set; }
    }
}