using System.Data.SqlClient;
using System.Data;
using CleaningBackTesting.Models.ResponseModels;
using CleaningBackTesting.RequestModels;
using Dapper;

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
            CleanerRegistrationRequestModel cleanerRegistration= new CleanerRegistrationRequestModel()
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
            };
            _id=cleaner.CleanerRegistration(cleanerRegistration);


            Client.AdminClient adminClient = new();
            string token=adminClient.Auth(new AuthRequestModel()
            {
                Password = "qwerty12345",
                Email = "Admin@gmail.com"
            });
           

            List<CleanerListResponseModel> cleaners = cleaner.GetCleaners(token);

            CleanerListResponseModel expected = new CleanerListResponseModel()
            {
                Id = _id,
                FirstName = cleanerRegistration.FirstName,
                LastName = "Skywalker",
                BirthDate = "1971-03-14T10:47:35.733Z",
                Email = EMAIL,
                Phone = "string",
                DateOfStartWork=DateTime.Now.ToString(),
                Rating=0
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
