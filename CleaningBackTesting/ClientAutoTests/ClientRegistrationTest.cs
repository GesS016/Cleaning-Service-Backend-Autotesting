using System;
using CleaningBackTesting.Client;
using CleaningBackTesting.RequestModels;
using NUnit.Framework;

namespace CleaningBackTesting.TestsClient
{
    public class ClientRegistrationTest
    {

        [Test]
        public void Test1()
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
<<<<<<< HEAD:CleaningBackTesting/ClientRegistrationTest.cs
            Client.Client client = new Client.Client();
<<<<<<< HEAD:CleaningBackTesting/ClientRegistrationTest.cs
            //string id = client.ClientRegistration(clientRegistrationRequestModel);
=======
            string id = client.ClientRegistration(clientRegistrationRequestModel);
=======
            ClientClient client = new ClientClient();
            int id = Convert.ToInt32(client.ClientRegistration(clientRegistrationRequestModel));
>>>>>>> CreatingСlient:CleaningBackTesting/ClientAutoTests/ClientRegistrationTest.cs
>>>>>>> ClientChange:CleaningBackTesting/ClientAutoTests/ClientRegistrationTest.cs
            //Assert.AreEqual(clientRegistrationRequestModel.Equals(clientRegistrationRequestModel), true);
        }
    }
}