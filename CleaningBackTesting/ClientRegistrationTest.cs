using System;
using CleaningBackTesting.Client;
using CleaningBackTesting.RequestModels;
using NUnit.Framework;

namespace CleaningBackTesting
{
    public class ClientRegistrationTest
    {
        ClientRegistrationRequestModel clientRegistrationRequestModel = new ClientRegistrationRequestModel()
        {
            FirstName = "Luke",
            LastName = "Skywalker",
            BirthDate = "1971-03-14T10:47:35.733Z",  //id 406
            Password = "stringst",
            ConfirmPassword = "stringst",
            Email = "lukesky@example.com",
            Phone = "string"
        };
        SuperClient client = new SuperClient();
        string id = client.ClientRegistration(ClientRegistrationRequestModel);
    }
}