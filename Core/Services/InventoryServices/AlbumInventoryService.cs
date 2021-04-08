using System.Collections.Generic;
using Core.Entities;

namespace Core.Services.InventoryServices
{

    public interface IAlbumInventoryService
    {
        List<Album> Get();
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
            };
            albums.Add(album);

            return albums;
        }           
    }
}
