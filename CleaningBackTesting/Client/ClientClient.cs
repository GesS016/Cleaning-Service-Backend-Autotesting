using CleaningBackTesting.Models.RequestModels;
using CleaningBackTesting.RequestModels;
using System.Net;
using System.Text.Json;


namespace CleaningBackTesting.Client
{
    public class ClientClient
    {
        private const string HOST = "https://piter-education.ru:10042";
        private const string CLIENTSHOST = HOST + "/Clients";
        public int ClientRegistration(ClientRegistrationRequestModel clientRegistrationRequestModel)
        {
            HttpStatusCode expectedCode = HttpStatusCode.Created;
            string json = JsonSerializer.Serialize<ClientRegistrationRequestModel>(clientRegistrationRequestModel);

            HttpResponseMessage responseMessage = MethodClients.SendRequest(HttpMethod.Post, CLIENTSHOST, jsonContent : json);

            HttpStatusCode actualCode = responseMessage.StatusCode;
            Assert.AreEqual(expectedCode, actualCode);

            int id =Convert.ToInt32( responseMessage.Content.ReadAsStringAsync().Result);

            return id;
        }

        public string Auth(AuthRequestModel clientAuthRequestModel)
        {
            HttpStatusCode expectedCode = HttpStatusCode.OK;
            string json = JsonSerializer.Serialize<AuthRequestModel>(clientAuthRequestModel);

            HttpResponseMessage responseMessage = MethodClients.SendRequest(HttpMethod.Post, HOST + "/auth", jsonContent: json);

            HttpStatusCode actualCode = responseMessage.StatusCode;
            Assert.AreEqual(expectedCode, actualCode);

            string token = responseMessage.Content.ReadAsStringAsync().Result;

            return token;
        }

        public int CreateOrder(OrdersRequestModel ordersRequestModel, string token)
        {
            HttpStatusCode expectedCode = HttpStatusCode.Created; 
            string json = JsonSerializer.Serialize<OrdersRequestModel>(ordersRequestModel);
           
            HttpResponseMessage responseMessage = MethodClients.SendRequest(HttpMethod.Post, CLIENTSHOST, token, json);

            HttpStatusCode actualCode = responseMessage.StatusCode;
            Assert.AreEqual(expectedCode, actualCode);

            int id = Convert.ToInt32(responseMessage.Content.ReadAsStringAsync().Result);

            return id;
        }

        public int CreateCleaningObject(CleaningObjectRequestModel cleaningObjectRequestModel, string token)
        {
            HttpStatusCode expectedCode = HttpStatusCode.Created;
            string json = JsonSerializer.Serialize<CleaningObjectRequestModel>(cleaningObjectRequestModel);

            HttpResponseMessage responseMessage = MethodClients.SendRequest(HttpMethod.Post, HOST+"/cleaning-objects", token, json);

            HttpStatusCode actualCode = responseMessage.StatusCode;
            Assert.AreEqual(expectedCode, actualCode);

            int id = Convert.ToInt32(responseMessage.Content.ReadAsStringAsync().Result);

            return id;
        }
    }
}
