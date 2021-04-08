using System.IO;
using Core.Services.SpotifyServices;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SpotifyController : Controller
    {
        private readonly ISpotifyApiHelper _spotifyApiHelper;
        private readonly string _path;

        public SpotifyController(ISpotifyApiHelper spotifyApiHelper)
        {
            _spotifyApiHelper = spotifyApiHelper;
            _path = Path.GetFullPath(ToString()!);
        }

        [HttpGet]
        public void Get()
        {
            var client = _spotifyApiHelper.InitializeClient();
        }
    }
}
