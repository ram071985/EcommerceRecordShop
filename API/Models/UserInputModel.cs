using System.Text.Json.Serialization;

namespace API.Controllers
{
    public class UserInputModel
    {
        [JsonPropertyName(("username"))] public string Username { get; set; }
        [JsonPropertyName(("password"))] public string Password { get; set; }
        [JsonPropertyName(("email"))] public string Email { get; set; }
    }
}