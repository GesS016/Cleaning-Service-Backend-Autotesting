using CleaningBackTesting.RequestModels;
using System.Net;
using System.Text.Json;
using CleaningBackTesting.Models.RequestModels;
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

            HttpResponseMessage responseMessage = MethodClients.SendRequest(HttpMethod.Post, HOST + "/auth", jsonContent : json);

            HttpStatusCode actualCode = responseMessage.StatusCode;
            Assert.AreEqual(expectedCode, actualCode);

            string token = responseMessage.Content.ReadAsStringAsync().Result;

            return token;
        }

        public int CleanerRegistration(CleanerRegistrationRequestModel cleanerRegistrationRequestModel, string token)
        {
            HttpStatusCode expectedCode = HttpStatusCode.Created;
            string json = JsonSerializer.Serialize<CleanerRegistrationRequestModel>(cleanerRegistrationRequestModel);

            HttpResponseMessage responseMessage = MethodClients.SendRequest(HttpMethod.Post, HOST+"/cleaners", token, json);

            HttpStatusCode actualCode = responseMessage.StatusCode;

            Assert.AreEqual(expectedCode, actualCode);

            int id = Convert.ToInt32(responseMessage.Content.ReadAsStringAsync().Result);
            return id;
        }

        public int CreateBundles(BundlesRequestModel bundlesRequestModel, string token)
        {
            HttpStatusCode expectedCode = HttpStatusCode.Created;
            string json = JsonSerializer.Serialize<BundlesRequestModel>(bundlesRequestModel);

            HttpResponseMessage responseMessage = MethodClients.SendRequest(HttpMethod.Post, HOST+"/Bundles", token, json);

            HttpStatusCode actualCode = responseMessage.StatusCode;
            Assert.AreEqual(expectedCode, actualCode);

            int id = Convert.ToInt32(responseMessage.Content.ReadAsStringAsync().Result);

            return id;
        }

        public int CreateService(ServiceRequestModel serviceRequestModel, string token)
        {
            HttpStatusCode expectedCode = HttpStatusCode.Created;
            string json = JsonSerializer.Serialize<ServiceRequestModel>(serviceRequestModel);

            HttpResponseMessage responseMessage = MethodClients.SendRequest(HttpMethod.Post, HOST + "/Services", token, json);

            HttpStatusCode actualCode = responseMessage.StatusCode;
            Assert.AreEqual(expectedCode, actualCode);

            int id = Convert.ToInt32(responseMessage.Content.ReadAsStringAsync().Result);

            return id;
        }

        public GetCleanerResponseModel GetCleanerById(string token, int id)
        {
            HttpStatusCode expectedCode = HttpStatusCode.OK;

            HttpResponseMessage responseMessage = MethodClients.SendRequest(HttpMethod.Get, HOST + $"/cleaners/{id}", token);

            HttpStatusCode actualCode = responseMessage.StatusCode;

            Assert.AreEqual(expectedCode, actualCode);

            string responseJson = responseMessage.Content.ReadAsStringAsync().Result;
            GetCleanerResponseModel cleaner = JsonSerializer.Deserialize<GetCleanerResponseModel>(responseJson)!;

            return cleaner;
        }

        
    }
}
