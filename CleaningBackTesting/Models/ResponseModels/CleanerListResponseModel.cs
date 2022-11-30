using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CleaningBackTesting.Models.ResponseModels
{
    public class CleanerListResponseModel
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
        public int Rating { get; set; }

/*        public override bool Equals(object? obj)
        {
            return obj is CleanerListResponseModel model &&
                FirstName == model.FirstName &&
                LastName == model.LastName &&
                Phone == model.Phone &&
                Email == model.Email &&
                Rating == model.Rating;
        }

        public override string ToString()
        {
            return FirstName;
        }*/
    }
}
