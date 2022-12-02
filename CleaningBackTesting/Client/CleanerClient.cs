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
            HttpResponseMessage responseMessage = SendRequest(HttpMethod.Get, CLEANERSHOST, token);

            HttpStatusCode actualCode = responseMessage.StatusCode;

            Assert.AreEqual(expectedCode, actualCode);

            string responseJson = responseMessage.Content.ReadAsStringAsync().Result;
            List<GetCleanerResponseModel> cleaners = JsonSerializer.Deserialize<List<GetCleanerResponseModel>>(responseJson)!;

            return cleaners;
        }

        private static HttpResponseMessage SendRequest(HttpMethod httpMethod, string uriString, string token = null, string jsonContent = null)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            HttpClient client = new HttpClient(clientHandler);
            if (!string.IsNullOrWhiteSpace(token))
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            HttpRequestMessage message = new HttpRequestMessage()
            {
                Method = httpMethod,
                RequestUri = new System.Uri(uriString)
            };
            if (!string.IsNullOrWhiteSpace(jsonContent))
            {
                message.Content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            }

            HttpResponseMessage responseMessage = client.Send(message);
            return responseMessage;
        }
    }
}
