using System;
using System.IO;
using Core.Entities;
using Core.Services.SpotifyServices;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public sealed class SpotifyController : Controller
    {
        private readonly ISpotifyAlbumService _albumService;
        private readonly string _path;

        public SpotifyController(ISpotifyAlbumService albumService)
        {
            _albumService = albumService;
            _path = Path.GetFullPath(ToString()!);
        }

        // TODO We shouldn't actually need this controller or endpoint
        [HttpGet("{albumId}")]
        public Album Get(string albumId)
        {
            return _albumService.GetAlbumBySpotifyId(albumId);
        }
    }
}