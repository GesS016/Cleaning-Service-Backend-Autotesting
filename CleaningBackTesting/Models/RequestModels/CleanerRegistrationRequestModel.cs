using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;
using Newtonsoft.Json;

namespace CleaningBackTesting.RequestModels
{
    public class CleanerRegistrationRequestModel
    {
    
        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonPropertyName("lastName")]
        public string LastName { get; set; }

        [JsonPropertyName("birthDate")]
        public string BirthDate { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }

        [JsonPropertyName("confirmPassword")]
        public string ConfirmPassword { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        [JsonPropertyName("passport")]
        public string Passport { get; set; }

        [JsonPropertyName("schedule")]
        public int Schedule { get; set; }

        [JsonPropertyName("servicesIds")]
        public List<int> ServicesIds { get; set; }

        [JsonPropertyName("districts")]
        public List<int> Districts { get; set; }
    }
}
