using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Authentication;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;


namespace Core.Services.SpotifyServices
{
    public interface ISpotifyApiHelper
    {
        Task<HttpClient> InitializeClient();
    }

    public class SpotifyApiHelper : ISpotifyApiHelper
    {
        private readonly string _clientId;
        private readonly string _clientSecret;

        public SpotifyApiHelper(IConfiguration configuration)
        {
            _clientId = configuration["Spotify:ClientId"];
            _clientSecret = configuration["Spotify:ClientSecret"];
        }


        public async Task<HttpClient> InitializeClient()
        {
            var tokenResponse = await GetApiToken();

            var apiClient = new HttpClient();
            
            apiClient.DefaultRequestHeaders.Accept.Clear();
            
            apiClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", tokenResponse.AccessToken);
            
            apiClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            return apiClient;
        }


        private async Task<TokenResponse> GetApiToken()
        {
            var url = "https://accounts.spotify.com/api/token";

            var requestBody = new Dictionary<string, string>
            {
                {"grant_type", "client_credentials"},
                {"client_id", _clientId},
                {"client_secret", _clientSecret}
            };

            using var client = new HttpClient();
            
            using var content = new FormUrlEncodedContent(requestBody);
            
            content.Headers.Clear();
            content.Headers.Add("Content-Type", "application/x-www-form-urlencoded");

            var response = await client.PostAsync(url, content);

            if (!response.IsSuccessStatusCode)
                throw new AuthenticationException("Could not get bearer token from Spotify");

            var tokenObject = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TokenResponse>(tokenObject);
        }
    }
}