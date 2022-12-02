﻿using CleaningBackTesting.Models.RequestModels;
using CleaningBackTesting.RequestModels;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

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

            HttpResponseMessage responseMessage = SendRequest(HttpMethod.Post, CLIENTSHOST, jsonContent : json);

            HttpStatusCode actualCode = responseMessage.StatusCode;
            Assert.AreEqual(expectedCode, actualCode);

            int id =Convert.ToInt32( responseMessage.Content.ReadAsStringAsync().Result);

            return id;
        }

        public string Auth(AuthRequestModel clientAuthRequestModel)
        {
            HttpStatusCode expectedCode = HttpStatusCode.OK;
            string json = JsonSerializer.Serialize<AuthRequestModel>(clientAuthRequestModel);

            HttpResponseMessage responseMessage = SendRequest(HttpMethod.Post, HOST + "/auth", jsonContent: json);

            HttpStatusCode actualCode = responseMessage.StatusCode;
            Assert.AreEqual(expectedCode, actualCode);

            string token = responseMessage.Content.ReadAsStringAsync().Result;

            return token;
        }

        public int CreateOrder(OrdersRequestModel ordersRequestModel, string token)
        {
            HttpStatusCode expectedCode = HttpStatusCode.Created; 
            string json = JsonSerializer.Serialize<OrdersRequestModel>(ordersRequestModel);
           
            HttpResponseMessage responseMessage = SendRequest(HttpMethod.Post, CLIENTSHOST, token, json);

            HttpStatusCode actualCode = responseMessage.StatusCode;
            Assert.AreEqual(expectedCode, actualCode);

            int id = Convert.ToInt32(responseMessage.Content.ReadAsStringAsync().Result);

            return id;
        }

        public int CreateCleaningObject(CleaningObjectRequestModel cleaningObjectRequestModel, string token)
        {
            HttpStatusCode expectedCode = HttpStatusCode.Created;
            string json = JsonSerializer.Serialize<CleaningObjectRequestModel>(cleaningObjectRequestModel);

            HttpResponseMessage responseMessage = SendRequest(HttpMethod.Post, HOST+"/cleaning-objects", token, json);

            HttpStatusCode actualCode = responseMessage.StatusCode;
            Assert.AreEqual(expectedCode, actualCode);

            int id = Convert.ToInt32(responseMessage.Content.ReadAsStringAsync().Result);

            return id;
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
