using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Integrations.Spotify.Objects
{
    [NotMapped]
    public class Album
    {
        public string SpotifyId { get; init; }
        public string Name { get; init; }
        public string ArtistName { get; init; }
        public string ArtistId { get; init; }
        public ArtistData ArtistData { get; set; }
        public string ImageUrl { get; init; }
        public string ReleaseDate { get; init; }
        public string RecordLabel { get; init; }
        public int TotalTracks { get; init; }
        public int Popularity { get; init; }
        public bool Explicit => Tracks.Any(track => track.Explicit);

        public string Description => $"{Name} came out {(ReleaseDate.Length > 4 ? "on" : "in")} " +
                                     $"{ReleaseDate} " +
                                     $"on {RecordLabel}{(RecordLabel.Contains("Records") ? "" : " Records")}. " +
                                     $"It was a {ParsePopularity()} for {ArtistName}. " +
                                     "Get your hands on a copy today!";
                                     
        public List<string> Collaborators { get; init; }
        public List<Track> Tracks { get; init; }

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