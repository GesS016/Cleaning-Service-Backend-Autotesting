using CleaningBackTesting.Models.ResponseModels;
using CleaningBackTesting.RequestModels;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace CleaningBackTesting.Client
{
    public class CleanerClient       //auth nujen???
    {
        private const string HOST = "https://piter-education.ru:10042";
        private const string CLEANERSHOST = HOST + "/Cleaners";
       
        public List<GetCleanerResponseModel> GetCleaners(string token)
        {
            HttpStatusCode expectedCode = HttpStatusCode.OK;
            HttpResponseMessage responseMessage = MethodClients.SendRequest(HttpMethod.Get, CLEANERSHOST, token);

            HttpStatusCode actualCode = responseMessage.StatusCode;

            Assert.AreEqual(expectedCode, actualCode);

            string responseJson = responseMessage.Content.ReadAsStringAsync().Result;
            List<GetCleanerResponseModel> cleaners = JsonSerializer.Deserialize<List<GetCleanerResponseModel>>(responseJson)!;

            return cleaners;
        }
    }
}
