using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public class Album
    {
        public short Id { get; set; }
        public string ArtistName { get; set; }
        public string AlbumName { get; set; }
        public decimal Price { get; set; }

        public static explicit operator List<object>(Album v)
        {
            throw new NotImplementedException();
        }
    }
}
