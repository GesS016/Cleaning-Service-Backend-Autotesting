using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CleaningBackTesting.Models.RequestModels
{
    public class BundlesRequestMoidel
    { 
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("type")]
        public int Type { get; set; }

        [JsonPropertyName("roomType")]
        public int RoomType { get; set; }

        [JsonPropertyName("price")]
        public int Price { get; set; }

        [JsonPropertyName("measure")]
        public int Measure { get; set; }

        [JsonPropertyName("servicesIds")]
        public List<int> ServicesIds { get; set; }
    }
}

