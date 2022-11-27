
using CleaningBackTesting.RequestModels;

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
                Email = "luke9999sky@example.com",
                Phone = "string"
            };
            AuthRequestModel clientAuthRequestModel = new AuthRequestModel()
            {
                Password="stringst",
                Email= "luke9999sky@example.com"
            };
            Client.ClientClient client = new Client.ClientClient();
            string token = client.Auth(clientAuthRequestModel);
            Assert.NotNull(token);
        }
    }
}