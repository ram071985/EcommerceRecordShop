using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    [NotMapped]
    public class Track
    {
        public string Name { get; set; }
        public int TrackNumber { get; set; }
        public int Duration { get; set; }
        public bool Explicit { get; set; }
    }
}