using System;
using System.Collections.Generic;
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

        [HttpGet("{albumId}")]
        public List<Album> Get(string albumId)
        {
            var albumIds = new string[] {albumId};
            return _albumService.GetAlbumsBySpotifyIds(albumIds);
        }

        [HttpPost]
        public List<Album> GetAlbums(List<string> spotifyIds)
        {
            return _albumService.GetAlbumsBySpotifyIds(spotifyIds);
        }
    }
}