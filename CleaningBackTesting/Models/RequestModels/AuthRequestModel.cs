using System.Text.Json.Serialization;

namespace CleaningBackTesting.RequestModels
{
    public class AuthRequestModel
    {
        [JsonPropertyName("password")]
        public string Password { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }
    }
}
