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

    public class SpotifyAlbumService: ISpotifyAlbumService
    {
        private readonly ISpotifyApiHelper _apiHelper;

        public SpotifyAlbumService(ISpotifyApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public Album GetAlbumBySpotifyId(string spotifyId)
        {
            var spotifyAlbumData = JsonConvert.DeserializeObject<AlbumData>(GetAlbumFromSpotify(spotifyId).Result);

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

        private async Task<string> GetAlbumFromSpotify(string spotifyId)
        {
            var url = $"https://api.spotify.com/v1/albums/{spotifyId}";
            var client = await _apiHelper.InitializeClient();

            var response = await client.GetAsync(url);
            if (!response.IsSuccessStatusCode)
                throw new Exception("invalid response from spotify");

            return await response.Content.ReadAsStringAsync();
        }
    }
}