using System;
using System.Collections;
using System.Collections.Generic;
using Core.Entities;

namespace Core.Services.InventoryServices
{

    public interface IAlbumInventoryService
    {

    }

    public class AlbumInventoryService : IAlbumInventoryService
    {
        public List<Album> Get()
        {
            var albums = new List<Album>();

            var album = new Album
            {
                Id = 1,
                ArtistName = "Stevie Wonder",
                AlbumName = "Innervisions",
                Price = 15.00M
            };
            albums.Add(album);

            return albums;
        }
            
    }
}
