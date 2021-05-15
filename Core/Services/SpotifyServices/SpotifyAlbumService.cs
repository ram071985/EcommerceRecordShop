using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Newtonsoft.Json;

namespace Core.Services.SpotifyServices
{
    public interface ISpotifyAlbumService
    {
        Album GetAlbumBySpotifyId(string spotifyId);
    }

    public class SpotifyAlbumService : ISpotifyAlbumService
    {
        private readonly ISpotifyApiHelper _apiHelper;

        public SpotifyAlbumService(ISpotifyApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public Album GetAlbumBySpotifyId(string spotifyId)
        {
            var albumData = GetAlbumFromSpotify(spotifyId).Result;
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
            
            var artistId = spotifyAlbumData.Artists[0].Id;

            var artistData = GetArtistFromSpotify(artistId).Result;
            var spotifyArtistData = JsonConvert.DeserializeObject<ArtistData>(artistData);

            var album = new Album
            {
                Name = spotifyAlbumData.Name,
                ArtistName = spotifyAlbumData.Artists[0].Name,
                ArtistId = spotifyAlbumData.Artists[0].Id,
                ArtistImageUrl= spotifyArtistData.ArtistImageUrls[0].Url,
                ImageUrl = spotifyAlbumData.Images[0].Url,
                Collaborators = collaborators,
                Tracks = tracks,
                TotalTracks = spotifyAlbumData.TotalTracks,
                ReleaseDate = Convert.ToDateTime(spotifyAlbumData.ReleaseDate),
                RecordLabel = spotifyAlbumData.RecordLabel,
                SpotifyId = spotifyId,
                Popularity = spotifyAlbumData.Popularity
            };
            
            return album;
        }

        private async Task<string> GetAlbumFromSpotify(string spotifyId)
        {
            var client = await _apiHelper.InitializeClient();

            var url = $"https://api.spotify.com/v1/albums/{spotifyId}";

            var response = await client.GetAsync(url);
            
            if (!response.IsSuccessStatusCode)
                throw new Exception("invalid response from spotify");

            return await response.Content.ReadAsStringAsync();
        }

        private async Task<string> GetArtistFromSpotify(string artistId)
        {
            var client = await _apiHelper.InitializeClient();

            var url = $"https://api.spotify.com/v1/artists/{artistId}";

            var response = await client.GetAsync(url);
            
            if (!response.IsSuccessStatusCode)
                throw new Exception("invalid response from spotify");

            return await response.Content.ReadAsStringAsync();
        }
        // private async Task<string> GetArtistImageFromSpotify(string artistId)
        // {
        // };
    }
}