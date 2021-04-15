using System.IO;
using System.Threading.Tasks;
using Core.Entities;
using Core.Services.SpotifyServices;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SpotifyController : Controller
    {
        private readonly ISpotifyAlbumService _albumService;
        private readonly string _path;

        public SpotifyController(ISpotifyAlbumService albumService)
        {
            _albumService = albumService;
            _path = Path.GetFullPath(ToString()!);
        }

        [HttpGet("{albumId}")]
        public Album Get(string albumId)
        {
            return _albumService.GetAlbumBySpotifyId(albumId);
        }
    }
}