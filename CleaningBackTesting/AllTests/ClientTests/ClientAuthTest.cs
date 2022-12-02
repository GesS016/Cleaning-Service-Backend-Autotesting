using CleaningBackTesting.RequestModels;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace CleaningBackTesting.TestsClient
{
    public class ClientTests
    {
        private const string EMAIL = "lukesky111@example.com";
        private const string PASSWORD = "stringst";
        private const string CONNECTIONSTRING = @"Data Source = 80.78.240.16; Initial Catalog = YogurtCleaning.DB; Persist Security Info = True; User ID = student; Password = qwe!23;";
        
        [Test]
        public void ClientAuthTest()
        {
            Client.ClientClient client = new ();
            client.ClientRegistration(new ClientRegistrationRequestModel()
            {
                FirstName = "Luke",
                LastName = "Skywalker",
                BirthDate = "1971-03-14T10:47:35.733Z",  
                Password = PASSWORD,
                ConfirmPassword = PASSWORD,
                Email = EMAIL,
                Phone = "string"
            });
            
            string token = client.Auth(new AuthRequestModel()
            {
                Password = PASSWORD,
                Email = EMAIL
            });
            Assert.NotNull(token);
        }

        [TearDown]
        public void ClientDelete()
        {
            using (IDbConnection dbConnection = new SqlConnection(CONNECTIONSTRING))
            {
                dbConnection.Query($"Delete from Client where Email='{EMAIL}'");
            }
        }
    }
}