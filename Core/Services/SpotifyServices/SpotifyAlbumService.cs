using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Newtonsoft.Json;

namespace Core.Services.SpotifyServices
{
    public interface ISpotifyAlbumService
    {
        List<Album> GetAlbumsBySpotifyIds(IEnumerable<string> spotifyIds);
        // Album GetAlbumBySpotifyId(string spotifyId);
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
            var rawAlbumData = GetAlbumsFromSpotify(spotifyIds).Result;

            var albumsData = rawAlbumData
                .Select(JsonConvert.DeserializeObject<AlbumData>)
                .ToList();

            var albums = albumsData.Select(albumData =>
                new Album
                {
                    Name = albumData.Name,
                    ArtistName = albumData.Artists[0].Name,
                    ArtistId = albumData.Artists[0].Id,
                    ImageUrl = albumData.Images[0].Url,
                    TotalTracks = albumData.TotalTracks,
                    ReleaseDate = Convert.ToDateTime(albumData.ReleaseDate),
                    RecordLabel = albumData.RecordLabel,
                    SpotifyId = albumData.Id,
                    Popularity = albumData.Popularity,
                    Collaborators = albumData.Artists.ConvertAll(artist => artist.Name),
                    Tracks = albumData.Tracks.Items.ConvertAll(item => new Track
                    {
                        Explicit = item.Explicit,
                        Duration = item.Duration / 1000,
                        Name = item.Name,
                        TrackNumber = item.TrackNumber
                    })
                }).ToList();

            var rawArtistData = GetArtistsFromSpotify(albums.ConvertAll(x => x.ArtistId)).Result;
            var artistData = rawArtistData
                .Select(JsonConvert.DeserializeObject<ArtistData>)
                .ToList();

            for (var i = 0; i < albums.Count; i++)
                albums[i].ArtistData = artistData[i];

            return albums;
        }

        private async Task<List<string>> GetArtistsFromSpotify(List<string> spotifyIds)
        {
            var client = await _apiHelper.InitializeClient();

            var uris = new List<Uri>();
            spotifyIds.ForEach(spotifyId => uris.Add(new Uri($"https://api.spotify.com/v1/artists/{spotifyId}")));

            var requests = uris
                .Select(uri => client.GetAsync(uri))
                .ToList();

            await Task.WhenAll(requests);

            var responses = requests
                .Select(async task => await task.Result.Content.ReadAsStringAsync())
                .ToList();

            var jsonArtists = new List<string>();
            responses.ForEach(async res =>
                jsonArtists.Add(item: await res));

            return jsonArtists;
        }

        private async Task<List<string>> GetAlbumsFromSpotify(IEnumerable<string> spotifyIds)
        {
            var client = await _apiHelper.InitializeClient();

            var uris = spotifyIds.Select(spotifyId => new Uri($"https://api.spotify.com/v1/albums/{spotifyId}"));

            var requests = uris
                .Select(uri => client.GetAsync(uri))
                .ToList();

            await Task.WhenAll(requests);

            var responses = requests
                .Select(async task => await task.Result.Content.ReadAsStringAsync())
                .ToList();

            var jsonAlbums = new List<string>();
            responses.ForEach(async res =>
                jsonAlbums.Add(item: await res));

            return jsonAlbums;
        }
        
        
        
        // TODO may remove these
        // public Album GetAlbumBySpotifyId(string spotifyId)
        // {
        //     var albumData = GetAlbumFromSpotify(spotifyId).Result;
        //     var spotifyAlbumData = JsonConvert.DeserializeObject<AlbumData>(albumData);
        //
        //     var tracks = new List<Track>();
        //     spotifyAlbumData.Tracks.Items.ForEach(track => tracks.Add(
        //         new Track
        //         {
        //             Name = track.Name,
        //             Duration = track.Duration / 1000,
        //             Explicit = track.Explicit,
        //             TrackNumber = track.TrackNumber
        //         }));
        //
        //     var collaborators = new List<string>();
        //     spotifyAlbumData.Artists.ForEach(artist => collaborators.Add(artist.Name));
        //
        //     var artistId = spotifyAlbumData.Artists[0].Id;
        //
        //     var artistData = GetArtistFromSpotify(artistId).Result;
        //     var spotifyArtistData = JsonConvert.DeserializeObject<ArtistData>(artistData);
        //
        //     var album = new Album
        //     {
        //         Name = spotifyAlbumData.Name,
        //         ArtistName = spotifyAlbumData.Artists[0].Name,
        //         ArtistId = spotifyAlbumData.Artists[0].Id,
        //         ArtistData = spotifyArtistData,
        //         ImageUrl = spotifyAlbumData.Images[0].Url,
        //         Collaborators = collaborators,
        //         Tracks = tracks,
        //         TotalTracks = spotifyAlbumData.TotalTracks,
        //         ReleaseDate = Convert.ToDateTime(spotifyAlbumData.ReleaseDate),
        //         RecordLabel = spotifyAlbumData.RecordLabel,
        //         SpotifyId = spotifyId,
        //         Popularity = spotifyAlbumData.Popularity
        //     };
        //
        //     return album;
        // }
        //
        //
        // private async Task<string> GetAlbumFromSpotify(string spotifyId)
        // {
        //     var client = await _apiHelper.InitializeClient();
        //
        //     var url = $"https://api.spotify.com/v1/albums/{spotifyId}";
        //
        //     var response = await client.GetAsync(url);
        //
        //     if (!response.IsSuccessStatusCode)
        //         throw new Exception("invalid response from spotify");
        //
        //     return await response.Content.ReadAsStringAsync();
        // }
        //
        // private async Task<string> GetArtistFromSpotify(string artistId)
        // {
        //     var client = await _apiHelper.InitializeClient();
        //
        //     var url = $"https://api.spotify.com/v1/artists/{artistId}";
        //
        //     var response = await client.GetAsync(url);
        //
        //     if (!response.IsSuccessStatusCode)
        //         throw new Exception("invalid response from spotify");
        //
        //     return await response.Content.ReadAsStringAsync();
        // }
        //
    }
}