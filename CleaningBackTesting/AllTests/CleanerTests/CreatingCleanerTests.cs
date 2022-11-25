using System;
using CleaningBackTesting.Client;
using CleaningBackTesting.RequestModels;
using NUnit.Framework;


namespace CleaningBackTesting.CleanerTests
{
    public class CreatingCleanerTests
    {

        [Test]
        public void CreateCleanerTest()
        {
            CleanerRegistrationRequestModel cleanerRegistrationRequestModel = new CleanerRegistrationRequestModel()
            {
                FirstName = "Luke",
                LastName = "Skywalker",
                BirthDate = "1971-03-14T10:47:35.733Z",  //id 406
                Password = "stringst",
                ConfirmPassword = "stringst",
                Email = "luke111sky@example.com",
                Phone = "string",
                Passport = "stringstri",
                Schedule = 1,
                ServicesIds = new List<int>() { }, 
                Districts = new List<int>() { }
            };

            Client.CleanerClient cleanerclient = new Client.CleanerClient();

            int id = Convert.ToInt32(cleanerclient.CleanerRegistration(cleanerRegistrationRequestModel));
            Assert.IsTrue(id > 0); //override sozdat nujno mb
        }
    }
}
