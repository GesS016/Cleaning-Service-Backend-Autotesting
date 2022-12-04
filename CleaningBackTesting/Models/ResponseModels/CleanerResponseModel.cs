using System.Text.Json.Serialization;

namespace CleaningBackTesting.Models.ResponseModels
{
    public class CleanerResponseModel : CleanerResponseModelBase
    {
        [JsonPropertyName("services")]
        public List<Services> Services { get; set; }

        public override string ToString()
        {
            return FirstName;
        }
    }
}
