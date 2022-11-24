using System;
using CleaningBackTesting.Client;
using CleaningBackTesting.RequestModels;
using NUnit.Framework;


namespace CleaningBackTesting.CleanerTests
{
    public class CreatingCleanerTest
    {

        [Test]
        public void Test1()
        {
            CleanerRegistrationRequestModel cleanerRegistrationRequestModel = new CleanerRegistrationRequestModel()
            {
                FirstName = "Luke",
                LastName = "Skywalker",
                BirthDate = "1971-03-14T10:47:35.733Z",  //id 406
                Password = "stringst",
                ConfirmPassword = "stringst",
                Email = "lukesky@example.com",
                Phone = "string",
                Passport = "stringstri",
                Schedule = 1,
                ServicesIds = { 0 }, //Maks pomogi
                Districts = { 1 }
            };
            Client.CleanerClient cleanerclient = new Client.CleanerClient();
            //string id = cleanerclient.CleanerRegistration(CleanerRegistrationRequestModel);
            //Assert.AreEqual(clientRegistrationRequestModel.Equals(clientRegistrationRequestModel), true);
        }
    }
}
