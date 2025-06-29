using System.Text.Json.Serialization;

namespace EnsekApiTests.Models
{
    public class LoginResponse
    {
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }
    }
}
