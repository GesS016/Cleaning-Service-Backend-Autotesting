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
    public class ClientClient
    {
        public int ClientRegistration(ClientRegistrationRequestModel clientRegistrationRequestModel)
        {
            HttpStatusCode expectedCode = HttpStatusCode.Created; //ожидаемый код=201
            string json = JsonSerializer.Serialize<ClientRegistrationRequestModel>(clientRegistrationRequestModel);
            //переводит наш файл ClientRegistrationRequestModel в json формат

            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }; 
            //for security certificate

            HttpClient client = new HttpClient(clientHandler);
            HttpRequestMessage message = new HttpRequestMessage()
            {
                Method = HttpMethod.Post, //Эндпоинт, в котором мы сейчас работаем(POST)
                RequestUri = new System.Uri($"https://piter-education.ru:10042/Clients"),//RequestURL из Swagger 
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };
            HttpResponseMessage responseMessage = client.Send(message);//response с сайта в формате месседжа

            HttpStatusCode actualCode = responseMessage.StatusCode;//actual код=код,выданный сайтом
            Assert.AreEqual(expectedCode, actualCode);//сравнение ожидаемого и actual кода

            int id =Convert.ToInt32( responseMessage.Content.ReadAsStringAsync().Result);//перевеодит айди в int

            return id;
        }

        

    }
}
