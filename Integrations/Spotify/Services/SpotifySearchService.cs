using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Integrations.Spotify.Objects;
using Newtonsoft.Json;

namespace Integrations.Spotify.Services
{
    public interface ISpotifySearchService
    {
        SearchResponse Search(string searchQuery);
    }

    public class SpotifySearchService : ISpotifySearchService
    {
        private readonly ISpotifyApiHelper _apiHelper;

        public SpotifySearchService(ISpotifyApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public SearchResponse Search(string searchQuery)
        {
            var rawAlbums = GetDataFromSpotify(searchQuery).Result;
            
            var albumsData = JsonConvert.DeserializeObject<SearchResponse>(rawAlbums);
                
            return albumsData;
        }

        private async Task<string> GetDataFromSpotify(string searchQuery)
        {
            var client = await _apiHelper.InitializeClient();

            var uri = new Uri($"https://api.spotify.com/v1/search?q={searchQuery}&type=album");

            var request = client.GetAsync(uri);

            var response = request.Result.Content.ReadAsStringAsync();

            var jsonData = await response;

            return jsonData;
        }
    }
}