using CleaningBackTesting.Client;
using CleaningBackTesting.RequestModels;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using CleaningBackTesting.Models.RequestModels;

namespace CleaningBackTesting
{
    public class CreateOrderTest
    {
        [Test]
        public void CreateOrderTest1()
        {
            Client.ClientClient client = new();
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

            Client.AdminClient admin=new AdminClient();
            AuthRequestModel adminAuthRequestModel = new AuthRequestModel()
            {
                Password = "qwerty12345",
                Email = "Admin@gmail.com"
            };
            
            CleaningObjectRequestModel cleaningObjectRequestModel = new CleaningObjectRequestModel()
            {
                NumberOfRooms= 1,
                NumberOfBalconies= 1,
                NumberOfBathrooms= 1,
                NumberOfWindows= 1,
                Square= 1,
                Address= "Aliyar Aliyev",
                District= 1,
                ClientId= 1
            };
        private const string EMAIL = "lukesky111@example.com";
        private const string PASSWORD = "stringst";
        private const string CONNECTIONSTRING = @"Data Source = 80.78.240.16; Initial Catalog = YogurtCleaning.DB; Persist Security Info = True; User ID = student; Password = qwe!23;";

        [Test]
        public void ClientAuthTest()
        {
            Client.ClientClient client = new();
            client.ClientRegistration(new ClientRegistrationRequestModel()
            {
                FirstName = "Luke",
                LastName = "Skywalker",
                BirthDate = "1971-03-14T10:47:35.733Z",  //id 406
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