using System;
using CleaningBackTesting.RequestModels;
using NUnit.Framework;

namespace CleaningBackTesting
{
    public class ClientRegistrationTest
    {
        ClientRegistrationRequestModel clientRegistrationRequestModel = new ClientRegistrationRequestModel()
        {
            FirstName = "Ilham",
            LastName = "Asadov",
            BirthDate = "1971-03-14T10:47:35.733Z",
            Password = "stringst",
            ConfirmPassword = "stringst",
            Email = "user@example.com",
            Phone = "string"
        };
    }
}