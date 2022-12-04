using CleaningBackTesting.RequestModels;
using System.Data.SqlClient;
using System.Data;
using Dapper;
using CleaningBackTesting;
using CleaningBackTesting.Models.ResponseModels;

namespace CleaningBackTesting.AllTests.CleanerTests
{
    public class GetCleanersTests
    {
        private const string EMAIL = "alximik@gmail.com";
        private const string PASSWORD = "stringst";
        private int _id;
        [Test]
        public void CleanersGetTest()
        {
            Client.AdminClient adminClient = new();
            string token = adminClient.Auth(new AuthRequestModel()
            {
                Password = "qwerty12345",
                Email = "Admin@gmail.com"
            });

            Client.AdminClient cleaner = new();
            cleaner.CleanerRegistration(new CleanerRegistrationRequestModel()
            {
                FirstName = "Ivan",
                LastName = "Alximik",
                BirthDate = "1971-03-14T10:47:35.733Z",
                Password = PASSWORD,
                ConfirmPassword = PASSWORD,
                Email = EMAIL,
                Phone = "string",
                Passport = "stringstri",
                Schedule = 1,
                ServicesIds = new List<int>() { },
                Districts = new List<int>() { }
            }, token);
            _id = cleaner.CleanerRegistration(cleanerRegistration);

            List<CleanerResponseModel> cleaners = cleaner.GetCleanerById(token);

            CleanerResponseModel expected = new CleanerResponseModel()
            {
                Id = _id,
                FirstName = cleanerRegistration.FirstName,
                LastName = "Skywalker",
                BirthDate = "1971-03-14T10:47:35.733Z",
                Email = EMAIL,
                Phone = "string",
                DateOfStartWork = DateTime.Now.ToString(),
                Rating = 0
            };

            CollectionAssert.Contains(cleaners, expected);
        }

        [TearDown]
        public void CleanerDelete()
        {
            using (IDbConnection dbConnection = new SqlConnection(@"Data Source = 80.78.240.16; Initial Catalog = YogurtCleaning.DB; Persist Security Info = True; User ID = student; Password = qwe!23;"))
            {
                dbConnection.Query($"Delete from CleanerOrder");
                dbConnection.Query($"Delete from CleanerService");
                dbConnection.Query($"Delete from CleanerDistrict");
                dbConnection.Query($"Delete from Cleaner");
            }
        }
    }
}
