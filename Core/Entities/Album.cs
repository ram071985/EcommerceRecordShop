using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Entities
{
    public class Album
    {
        public string SpotifyId { get; set; }
        public string Name { get; set; }
        public string ArtistName { get; set; }
        public string ArtistId { get; set; }
        public string ArtistImageUrl { get; set; }
        public string ImageUrl { get; set; }
        public DateTime ReleaseDate { get; set; }
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
            return Popularity switch
            {
                > 75 => "HUGE release",
                > 55 => "Big release",
                > 40 => "Fairly Successful album",
                _ => "album with a cult following"
            };
        }
    }
}