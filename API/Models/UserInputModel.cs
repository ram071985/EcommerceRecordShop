using System.Text.Json.Serialization;

namespace API.Models
{
    public class UserInputModel
    {
        [JsonPropertyName(("username"))] public string Username { get; set; }
        [JsonPropertyName(("password"))] public string Password { get; set; }
        [JsonPropertyName(("email"))] public string Email { get; set; }
    }
}