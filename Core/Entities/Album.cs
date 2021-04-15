using System;
using System.Collections.Generic;
using System.Linq;

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
        public int Popularity { get; set; }
        public string Description => $"{Name} came out on {ReleaseDate.DayOfWeek}, " +
                                     $"{ReleaseDate.Month}/{ReleaseDate.Day}/{ReleaseDate.Year}" +
                                     $" on {RecordLabel} Records. It was a {ParsePopularity()} for {ArtistName}. " +
                                     "Get your hands on a copy today!";
        public bool Explicit => Tracks.Any(track => track.Explicit);
        public List<string> Collaborators { get; set; }
        public List<Track> Tracks { get; set; }

        private string ParsePopularity()
        {
            if (Popularity > 75) return "HUGE release";
            if (Popularity > 55) return "Big release";
            if (Popularity > 40) return "Fairly Successful album";
            return "album with a cult following";
        }
    }

    public class Track
    {
        public string Name { get; set; }
        public int TrackNumber { get; set; }
        public int Duration { get; set; }
        public bool Explicit { get; set; }
    }
}