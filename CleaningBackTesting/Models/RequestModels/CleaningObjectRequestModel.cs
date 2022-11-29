using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CleaningBackTesting.Models.RequestModels
{
    public class CleaningObjectRequestModel
    {
        [JsonPropertyName("numberOfRooms")]
        public long NumberOfRooms { get; set; }

        [JsonPropertyName("numberOfBathrooms")]
        public long NumberOfBathrooms { get; set; }

        [JsonPropertyName("square")]
        public long Square { get; set; }

        [JsonPropertyName("numberOfWindows")]
        public long NumberOfWindows { get; set; }

        [JsonPropertyName("numberOfBalconies")]
        public long NumberOfBalconies { get; set; }

        [JsonPropertyName("address")]
        public string Address { get; set; }

        [JsonPropertyName("district")]
        public int District { get; set; }

        [JsonPropertyName("clientId")]
        public int ClientId { get; set; }
    }
}
