using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Core.Entities;
using Newtonsoft.Json;

namespace Core.Services.SpotifyServices
{
    public interface ISpotifyAlbumService
    {
        Task<Album> GetAlbumBySpotifyId(string spotifyId);
    }

    public class SpotifyAlbumService : ISpotifyAlbumService
    {
        private readonly ISpotifyApiHelper _apiHelper;

        public SpotifyAlbumService(ISpotifyApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public async Task<Album> GetAlbumBySpotifyId(string spotifyId)
        {
            var url = $"https://api.spotify.com/v1/albums/{spotifyId}";
            var client = await GetClient();

            var response = await client.GetAsync(url);
            var albumData = await response.Content.ReadAsStringAsync();
            var spotifyAlbumData = JsonConvert.DeserializeObject<AlbumData>(albumData);

            var tracks = new List<Track>();
            spotifyAlbumData.Tracks.Items.ForEach(track => tracks.Add(
                new Track
                {
                    Name = track.Name,
                    Duration = track.Duration / 1000,
                    Explicit = track.Explicit,
                    TrackNumber = track.TrackNumber
                }));

            var collaborators = new List<string>();
            spotifyAlbumData.Artists.ForEach(artist => collaborators.Add(artist.Name));

            var album = new Album
            {
                Name = spotifyAlbumData.Name,
                ArtistName = spotifyAlbumData.Artists[0].Name,
                Collaborators = collaborators,
                Tracks = tracks,
                TotalTracks = spotifyAlbumData.TotalTracks,
                ReleaseDate = Convert.ToDateTime(spotifyAlbumData.ReleaseDate),
                ImageUrl = spotifyAlbumData.Images[0].Url,
                RecordLabel = spotifyAlbumData.RecordLabel,
                SpotifyId = spotifyId
            };

            return album;
        }

        private async Task<HttpClient> GetClient()
        {
            var client = await _apiHelper.InitializeClient();
            return client;
        }
    }
}