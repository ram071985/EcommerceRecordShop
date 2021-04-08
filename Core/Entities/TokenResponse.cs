using Newtonsoft.Json;

namespace Core.Entities
{
    public class TokenResponse
    {
        [JsonProperty("access_token")] 
        public string AccessToken { get; set; }
    }
}