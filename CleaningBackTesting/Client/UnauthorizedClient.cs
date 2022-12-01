using CleaningBackTesting.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CleaningBackTesting.Client
{
    public class UnauthorizedClient
    {
        private const string HOST = "https://piter-education.ru:10042";
        public string Auth(AuthRequestModel cleanerAuthRequestModel)
        {
            HttpStatusCode expectedCode = HttpStatusCode.OK;

            string json = JsonSerializer.Serialize<AuthRequestModel>(cleanerAuthRequestModel);

            HttpResponseMessage responseMessage = SendRequest(HttpMethod.Post, HOST + "/Auth", jsonContent: json);

            HttpStatusCode actualCode = responseMessage.StatusCode;

            Assert.AreEqual(expectedCode, actualCode);

            string token = responseMessage.Content.ReadAsStringAsync().Result;

            return token;
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
