using CleaningBackTesting.Client;
using CleaningBackTesting.RequestModels;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using CleaningBackTesting.Models.RequestModels;
using Dapper;

namespace CleaningBackTesting
{
    public class CreateOrderTest
    {
        private int _serviceId;
        private int _cleaningObjectId;
        private int _bundlesId;
        private int _orderId;
        private const string EMAIL = "luke11123sky@example.com";
        private const string PASSWORD = "stringst";
        private const string CONNECTIONSTRING = @"Data Source = 80.78.240.16; Initial Catalog = YogurtCleaning.DB; Persist Security Info = True; User ID = student; Password = qwe!23;";

        [Test]
        public void CreateOrderTest1()
        {
            Client.ClientClient client = new();
            int clientId=client.ClientRegistration(new ClientRegistrationRequestModel()
            {
                FirstName = "Luke",
                LastName = "Skywalker",
                BirthDate = "1971-03-14T10:47:35.733Z",
                Password = PASSWORD,
                ConfirmPassword = PASSWORD,
                Email = EMAIL,
                Phone = "string"
            });

            Client.AdminClient admin = new();
            string token=admin.Auth(new AuthRequestModel()
            {
                Password = "qwerty12345",
                Email = "Admin@gmail.com"
            });

            _serviceId = admin.CreateService(new ServiceRequestModel()
            {
                Name = "string",
                RoomType = 1,
                Price = 50,
                Unit = "string",
                Duration = 0
            },token);

            _bundlesId = admin.CreateBundles(new BundlesRequestModel()
            {
                Name = "string",
                Type = 1,
                RoomType = 1,
                Price = 500,
                Measure = 1,
                ServicesIds = new List<int>() {_serviceId},
            }, token);

            string clientToken = client.Auth(new AuthRequestModel()
            {
                Password = PASSWORD,
                Email = EMAIL
            });

            _cleaningObjectId=client.CreateCleaningObject(new CleaningObjectRequestModel()
            {
                NumberOfRooms = 1,
                NumberOfBalconies = 1,
                NumberOfBathrooms = 1,
                NumberOfWindows = 1,
                Square = 1,
                Address = "Aliyar Aliyev",
                District = 1,
                ClientId = 1
            },clientToken);

            _orderId = client.CreateOrder(new OrdersRequestModel()
            {
                ClientId = clientId,
                CleaningObjectId = _cleaningObjectId,
                StartTime = "2022-12-01T22:50:58.106Z",
                BundlesIds = new List<int>() {_bundlesId},
                ServicesIds = new List<int>() {_serviceId},
            }, clientToken);

            Assert.NotNull(_orderId);
        }

        [TearDown]
        public void Delete()
        {
            using (IDbConnection dbConnection = new SqlConnection(CONNECTIONSTRING))
            {
                dbConnection.Query($"Delete from Client where Email='{EMAIL}'");
                dbConnection.Query($"Delete from Service where Id='{_serviceId}'"); 
                dbConnection.Query($"Delete from Bundle where Id='{_bundlesId}'");
                dbConnection.Query($"Delete from CleaningObject where Id='{_cleaningObjectId}'");
                dbConnection.Query($"Delete from Order where Id='{_orderId}'");
            }
        }
    }
}