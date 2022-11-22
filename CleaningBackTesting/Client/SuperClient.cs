using CleaningBackTesting.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CleaningBackTesting.Client
{
    public class SuperClient
    {
        public string ClientRegistration(ClientRegistrationRequestModel clientRegistrationRequestModel)
        {
            HttpStatusCode expectedCode = HttpStatusCode.Created;
            string json = JsonSerializer.Serialize<ClientRegistrationRequestModel>(clientRegistrationRequestModel);

            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }; //for security certificate

            HttpClient client = new HttpClient(clientHandler);
            HttpRequestMessage message = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new System.Uri($"https://piter-education.ru:10042/Clients"),
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };
            HttpResponseMessage responseMessage = client.Send(message);

            HttpStatusCode actualCode = responseMessage.StatusCode;
            Assert.AreEqual(expectedCode, actualCode);

            string id = responseMessage.Content.ReadAsStringAsync().Result;

            return id;
        }
    }
}
