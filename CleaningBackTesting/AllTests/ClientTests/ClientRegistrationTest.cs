
using CleaningBackTesting.RequestModels;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace CleaningBackTesting.TestsClient
{
    public class ClientTests
    {

        [Test]
        public void ClientRegistrationTest()
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
            AuthRequestModel clientAuthRequestModel = new AuthRequestModel()
            {
                Password="stringst",
                Email= "lukesky@example.com"
            };
            Client.ClientClient client = new Client.ClientClient();
            string token = client.Auth(clientAuthRequestModel);
            Assert.NotNull(token);
        }

        [TearDown]
        public void ClientDelete()
        {
            string connectionString = @"Data Source = 80.78.240.16; Initial Catalog = YogurtCleaning.DB; Persist Security Info = True; User ID = student; Password = qwe!23;";
            IDbConnection dbConnection = new SqlConnection(connectionString);
            dbConnection.Open();
            dbConnection.Query("Delete Comment");
            dbConnection.Query("Delete BundleOrder");
            dbConnection.Query("Delete CleanerOrder");
            dbConnection.Query("Delete [Order]");
            dbConnection.Query("Delete CleaningObject");
            dbConnection.Query("Delete Client");
            dbConnection.Close();
        }
    }
}