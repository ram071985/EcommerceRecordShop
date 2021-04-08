using System.Collections.Generic;
using System.Linq;
using API.Models;
using Core.Services.InventoryServices;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public sealed class AlbumController : Controller
    {
        private readonly IAlbumInventoryService _albumInventoryService;
    
        public AlbumController(IAlbumInventoryService albumInventoryService)
        {
            _albumInventoryService = albumInventoryService;

        }

        // Get current in-stock albums from database
        [HttpGet]
        public List<AlbumModel> GetAlbums()
        {
            // TODO should return List<Albums>()
            var albums = _albumInventoryService.Get();

            var albumModels = albums.Select(album => new AlbumModel
            {
                Id = album.Id,
                ArtistName = album.ArtistName,
                // AlbumName = album.AlbumName,
                // Price = album.Price
            });
            return albumModels.ToList();            
        }
    }
}
