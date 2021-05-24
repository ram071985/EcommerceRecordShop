using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Integrations.Spotify.Objects
{
    [NotMapped]
    public class TokenResponse
    {
        [JsonProperty("access_token")] 
        public string AccessToken { get; set; }
    }
}