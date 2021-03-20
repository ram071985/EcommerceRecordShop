using System.Collections.Generic;
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
        [HttpGet("albums")]
        public List<AlbumModel> GetAlbums()
        {
            // TODO should return List<Albums>()
            return new List<AlbumModel>();            
        }
    }
}
