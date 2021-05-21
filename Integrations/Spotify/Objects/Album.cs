using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Integrations.Spotify.Objects
{
    [NotMapped]
    public class Album
    {
        public string SpotifyId { get; set; }
        public string Name { get; set; }
        public string ArtistName { get; set; }
        public string ArtistId { get; set; }
        public ArtistData ArtistData { get; set; }
        public string ImageUrl { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string RecordLabel { get; set; }
        public int TotalTracks { get; set; }
        public int Popularity { get; set; }
        public bool Explicit => Tracks.Any(track => track.Explicit);

        public string Description => $"{Name} came out on {ReleaseDate.DayOfWeek}, " +
                                     $"{ReleaseDate.Month}/{ReleaseDate.Day}/{ReleaseDate.Year} " +
                                     $"on {RecordLabel}{(RecordLabel.Contains("Records") ? "" : " Records")}. " +
                                     $"It was a {ParsePopularity()} for {ArtistName}. " +
                                     "Get your hands on a copy today!";

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