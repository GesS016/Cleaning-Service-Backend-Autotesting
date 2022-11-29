using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CleaningBackTesting.Models.RequestModels
{
    public class ServiceRequestModel
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("roomType")]
        public int RoomType { get; set; }

        [JsonPropertyName("price")]
        public int Price { get; set; }

        [JsonPropertyName("unit")]
        public string Unit { get; set; }

        [JsonPropertyName("duration")]
        public int Duration { get; set; }
    }
}

