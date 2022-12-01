using CleaningBackTesting.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using CleaningBackTesting.Models.RequestModels;
using System.Net.Http.Headers;
using CleaningBackTesting.Models.ResponseModels;

namespace CleaningBackTesting.Client
{
    public class AdminClient
    {
        private const string HOST = "https://piter-education.ru:10042";
        public string Auth(AuthRequestModel adminAuthRequestModel)
        {
            HttpStatusCode expectedCode = HttpStatusCode.OK;
            string json = JsonSerializer.Serialize<AuthRequestModel>(adminAuthRequestModel);
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            HttpClient client = new HttpClient(clientHandler);
            HttpRequestMessage message = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new System.Uri($"https://piter-education.ru:10042/Auth"),
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };
            HttpResponseMessage responseMessage = client.Send(message);
            HttpStatusCode actualCode = responseMessage.StatusCode;
            Assert.AreEqual(expectedCode, actualCode);

            string token = responseMessage.Content.ReadAsStringAsync().Result;

            return token;
        }

        public int CleanerRegistration(CleanerRegistrationRequestModel cleanerRegistrationRequestModel, string token)
        {
            HttpStatusCode expectedCode = HttpStatusCode.Created;
            string json = JsonSerializer.Serialize<CleanerRegistrationRequestModel>(cleanerRegistrationRequestModel);

            HttpResponseMessage responseMessage = SendRequest(HttpMethod.Post, HOST+"/cleaners", token, json);

            HttpStatusCode actualCode = responseMessage.StatusCode;

            Assert.AreEqual(expectedCode, actualCode);

            int id = Convert.ToInt32(responseMessage.Content.ReadAsStringAsync().Result);
            return id;
        }

        public int CreateCleaningObject(BundlesRequestModel creatingObjectRequestModel)
        {
            HttpStatusCode expectedCode = HttpStatusCode.Created;
            string json = JsonSerializer.Serialize<BundlesRequestModel>(creatingObjectRequestModel);

            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            HttpClient client = new HttpClient(clientHandler);
            HttpRequestMessage message = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new System.Uri($"https://piter-education.ru:10042/cleaning-objects"),
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };
            HttpResponseMessage responseMessage = client.Send(message);

            HttpStatusCode actualCode = responseMessage.StatusCode;
            Assert.AreEqual(expectedCode, actualCode);

            int id = Convert.ToInt32(responseMessage.Content.ReadAsStringAsync().Result);

            return id;
        }
        public int CreateService(BundlesRequestModel serviceRequestModel)
        {
            HttpStatusCode expectedCode = HttpStatusCode.Created;
            string json = JsonSerializer.Serialize<BundlesRequestModel>(serviceRequestModel);

            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            HttpClient client = new HttpClient(clientHandler);
            HttpRequestMessage message = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new System.Uri($"https://piter-education.ru:10042/Services"),
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };
            HttpResponseMessage responseMessage = client.Send(message);

            HttpStatusCode actualCode = responseMessage.StatusCode;
            Assert.AreEqual(expectedCode, actualCode);

            int id = Convert.ToInt32(responseMessage.Content.ReadAsStringAsync().Result);

            return id;
        }
        public int CreateBundles(BundlesRequestModel bundlesRequestModel, string token)
        {
            HttpStatusCode expectedCode = HttpStatusCode.Created;
            string json = JsonSerializer.Serialize<BundlesRequestModel>(bundlesRequestModel);

            HttpResponseMessage responseMessage = SendRequest(HttpMethod.Post, HOST+"/Bundles", token, json);

            HttpStatusCode actualCode = responseMessage.StatusCode;
            Assert.AreEqual(expectedCode, actualCode);

            int id = Convert.ToInt32(responseMessage.Content.ReadAsStringAsync().Result);

            return id;
        }

        public int CreateService(ServiceRequestModel serviceRequestModel, string token)
        {
            HttpStatusCode expectedCode = HttpStatusCode.Created;
            string json = JsonSerializer.Serialize<ServiceRequestModel>(serviceRequestModel);

            HttpResponseMessage responseMessage = SendRequest(HttpMethod.Post, HOST + "/Services", token, json);

            HttpStatusCode actualCode = responseMessage.StatusCode;
            Assert.AreEqual(expectedCode, actualCode);

            int id = Convert.ToInt32(responseMessage.Content.ReadAsStringAsync().Result);

            return id;
        }

        public GetCleanerResponseModel GetCleanerById(string token, int id)
        {
            HttpStatusCode expectedCode = HttpStatusCode.OK;

            HttpResponseMessage responseMessage = SendRequest(HttpMethod.Get, HOST + $"/cleaners/{id}", token);

            HttpStatusCode actualCode = responseMessage.StatusCode;

            Assert.AreEqual(expectedCode, actualCode);

            string responseJson = responseMessage.Content.ReadAsStringAsync().Result;
            GetCleanerResponseModel cleaner = JsonSerializer.Deserialize<GetCleanerResponseModel>(responseJson)!;

            return cleaner;
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
