using System.Text.Json.Serialization;

namespace CleaningBackTesting.Models.ResponseModels
{
    public class Services
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("roomType")]
        public int RoomType { get; set; }

        [JsonPropertyName("price")]
        public int Price { get; set; }

        [JsonPropertyName("unit")]
        public string Unit { get; set; }

        [JsonPropertyName("duration")]
        public double Duration { get; set; }
    }
}
