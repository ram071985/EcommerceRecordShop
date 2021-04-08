using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public class Product
    {
        public short Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string AlbumId { get; set; }
    }
    public class Album
    {
        public short Id { get; set; }
        public string SpotifyId { get; set; }
        public string Name { get; set; }
        public string ArtistName { get; set; }
        public List<string> Collaborators { get; set; }
        public string Description { get; set; }
        public Date ReleaseDate { get; set; }
        public string ImageUrl { get; set; }
    }
    public class SpotifyAlbum
    {
        
    }
}
