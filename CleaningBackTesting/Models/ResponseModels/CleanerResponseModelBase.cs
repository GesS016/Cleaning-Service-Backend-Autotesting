using System.Text.Json.Serialization;

namespace CleaningBackTesting.Models.ResponseModels
{
    public class CleanerResponseModelBase
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }

        [JsonPropertyName("lastName")]
        public string LastName { get; set; }

        [JsonPropertyName("dateOfStartWork")]
        public string DateOfStartWork { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        [JsonPropertyName("birthDate")]
        public string BirthDate { get; set; }

        [JsonPropertyName("rating")]
        public double Rating { get; set; }
    }
}