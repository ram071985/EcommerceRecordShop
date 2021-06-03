using System;
using System.Collections.Generic;
using System.IO;
using Integrations.Spotify.Objects;
using Integrations.Spotify.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController, Route("[controller]")]
    public sealed class SpotifyController : Controller
    {
        private readonly ISpotifyAlbumService _albumService;
        private readonly ISpotifySearchService _searchService;
        private readonly string _path;

        public SpotifyController(
            ISpotifyAlbumService albumService,
            ISpotifySearchService searchService)
        {
            _albumService = albumService;
            _searchService = searchService;
            _path = Path.GetFullPath(ToString()!);
        }

        [HttpGet("{albumId}")]
        public List<Album> Get(string albumId)
        {
            var albumIds = new[] { albumId };
            return _albumService.GetAlbumsBySpotifyIds(albumIds);
        }

        [HttpGet("search/{searchQuery}")]
        public SearchResponse Search(string searchQuery)
        {
            Console.WriteLine($"search hit with {searchQuery}");
            return _searchService.Search(searchQuery);
        }

        [HttpPost]
        public List<Album> GetAlbums(List<string> spotifyIds)
        {
            return _albumService.GetAlbumsBySpotifyIds(spotifyIds);
        }
    }
}
