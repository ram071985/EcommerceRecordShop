using System.ComponentModel.DataAnnotations.Schema;

namespace Integrations.Spotify.Objects
{
    [NotMapped]
    public class Track
    {
        public string Name { get; init; }
        public int TrackNumber { get; init; }
        public int Duration { get; init; }
        public bool Explicit { get; init; }
    }
}