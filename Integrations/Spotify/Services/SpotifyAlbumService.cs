using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Integrations.Spotify.Objects;
using Newtonsoft.Json;

namespace Integrations.Spotify.Services
{
    public interface ISpotifyAlbumService
    {
        List<Album> GetAlbumsBySpotifyIds(IEnumerable<string> spotifyIds);
    }

    public class SpotifyAlbumService : ISpotifyAlbumService
    {
        private readonly ISpotifyApiHelper _apiHelper;

        public SpotifyAlbumService(ISpotifyApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public List<Album> GetAlbumsBySpotifyIds(IEnumerable<string> spotifyIds)
        {
            var rawAlbumData = GetDataFromSpotify("albums", spotifyIds).Result;

            var albumsData = JsonConvert.DeserializeObject<AlbumsData>(rawAlbumData);

            var albums = albumsData.AlbumsList.Select(albumData =>
                new Album
                {
                    Name = albumData.Name,
                    ArtistName = albumData.Artists[0].Name,
                    ArtistId = albumData.Artists[0].Id,
                    ImageUrl = albumData.Images[0].Url,
                    TotalTracks = albumData.TotalTracks,
                    ReleaseDate = albumData.ReleaseDate,
                    RecordLabel = albumData.RecordLabel,
                    SpotifyId = albumData.Id,
                    Popularity = albumData.Popularity,
                    Collaborators = albumData.Artists.ConvertAll(artist => artist.Name),
                    Tracks = albumData.Tracks.Items.ConvertAll(item => new Track
                    {
                        Explicit = item.Explicit,
                        Duration = item.Duration / 1000, // transform ms to seconds
                        Name = item.Name,
                        TrackNumber = item.TrackNumber
                    })
                }).ToList();

            var rawArtistData = GetDataFromSpotify("artists", albums.ConvertAll(x => x.ArtistId)).Result;

            var artistsData = JsonConvert.DeserializeObject<ArtistsData>(rawArtistData);

            for (var i = 0; i < albums.Count; i++)
                albums[i].ArtistData = artistsData.ArtistsList[i];

            return albums;
        }

        private async Task<string> GetDataFromSpotify(string requestType, IEnumerable<string> spotifyIds)
        {
            var client = await _apiHelper.InitializeClient();

            var queryParameterIds = spotifyIds.Aggregate((x, y) => x + "," + y);

            var uri = new Uri($"https://api.spotify.com/v1/{requestType}?ids={queryParameterIds}");

            var request = client.GetAsync(uri);

            var response = request.Result.Content.ReadAsStringAsync();

            var jsonData = await response;

            return jsonData;
        }
    }
}