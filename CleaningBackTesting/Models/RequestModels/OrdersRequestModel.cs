using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CleaningBackTesting.Models.RequestModels
{
    public class OrdersRequestModel
    {
        [JsonPropertyName("clientId")]
        public int ClientId { get; set; }

        [JsonPropertyName("cleaningObjectId")]
        public int CleaningObjectId { get; set; }

        [JsonPropertyName("startTime")]
        public DateTime StartTime { get; set; }

        [JsonPropertyName("bundlesIds")]
        public List<int> BundlesIds { get; set; }

        [JsonPropertyName("servicesIds")]
        public List<int> ServicesIds { get; set; }
    }
}

