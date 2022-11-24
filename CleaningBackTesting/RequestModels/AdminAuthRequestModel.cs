using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CleaningBackTesting.RequestModels
{
    public class AdminAuthRequestModel
    {
        [JsonPropertyName("password")]
        public string Password { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }
    }

}
