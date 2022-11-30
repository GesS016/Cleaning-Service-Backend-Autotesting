using System;
using System.Data.SqlClient;
using System.Data;
using CleaningBackTesting.Client;
using CleaningBackTesting.Models.ResponseModels;
using CleaningBackTesting.RequestModels;
using NUnit.Framework;
using System.Runtime.CompilerServices;
using Dapper;
using NUnit.Framework.Constraints;

namespace CleaningBackTesting.CleanerTests
{
    public class CleanerTests
    {
        private const string EMAIL = "luke11123sky@example.com";
        private const string PASSWORD = "stringst";
        private  int _id ;
        [Test]
        public void CreateCleanerTest()
        {
            Client.CleanerClient cleaner = new();
            _id=cleaner.CleanerRegistration(new CleanerRegistrationRequestModel()
            //CleanerRegistrationRequestModel cleanerRegistrationRequestModel = new CleanerRegistrationRequestModel()
            {
                FirstName = "Luke",
                LastName = "Skywalker",
                BirthDate = "1971-03-14T10:47:35.733Z",  
                Password = PASSWORD,
                ConfirmPassword = PASSWORD,
                Email = EMAIL,
                Phone = "string",
                Passport = "stringstri",
                Schedule = 1,
                ServicesIds = new List<int>() {},
                Districts = new List<int>() {}
            });


            //Client.CleanerClient cleanerclient = new Client.CleanerClient();

            //int id = Convert.ToInt32(cleanerclient.CleanerRegistration(cleanerRegistrationRequestModel));
            //Assert.IsTrue(id > 0);

            Client.AdminClient adminClient = new();
            string token=adminClient.Auth(new AuthRequestModel()
            {
                Password = "qwerty12345",
                Email = "Admin@gmail.com"
            });
            //CleanerClient client = new CleanerClient();

            //string token = client.Auth(authInputModel);


            List<CleanerListResponseModel> cleaners = cleaner.GetCleaners(token);

            CollectionAssert.Contains(cleaners, cleaner);
        }

        [TearDown]
        public void CleanerDelete()
        {
            using (IDbConnection dbConnection = new SqlConnection(@"Data Source = 80.78.240.16; Initial Catalog = YogurtCleaning.DB; Persist Security Info = True; User ID = student; Password = qwe!23;"))
            {
                dbConnection.Query($"Delete from CleanerDistrict where CleanersId={_id}");
                dbConnection.Query($"Delete from Cleaner where Email='{EMAIL}'");
            }
        }
    }
}
