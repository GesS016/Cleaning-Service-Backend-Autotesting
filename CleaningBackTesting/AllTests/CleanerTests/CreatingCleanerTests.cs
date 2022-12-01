using CleaningBackTesting.Client;
using CleaningBackTesting.Models.ResponseModels;
using CleaningBackTesting.RequestModels;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace CleaningBackTesting.CleanerTests
{
    public class CleanerTests
    {
        private const string EMAIL = "luke11123sky@example.com";
        private const string PASSWORD = "stringst";
        private int id;
        [Test]
        public void CreateCleanerTest()
        {
            CleanerClient client = new();
            id = client.CleanerRegistration(new CleanerRegistrationRequestModel()
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
                ServicesIds = new List<int>() { },
                Districts = new List<int>() { }
            });

            AdminClient adminClient = new();
            string token = adminClient.Auth(new AuthRequestModel()
            {
                Password = "qwerty12345",
                Email = "Admin@gmail.com"
            });

            GetCleanerResponseModel cleaner = client.GetCleanerById(token, id);

            Assert.IsNotNull(cleaner);
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
