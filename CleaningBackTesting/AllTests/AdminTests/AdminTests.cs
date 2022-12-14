using CleaningBackTesting.Client;
using CleaningBackTesting.RequestModels;

namespace CleaningBackTesting
{
    public class AdminTests
    {
        [Test]
        public void AdminAuthTest()
        {
            AuthRequestModel adminAuthRequestModel = new AuthRequestModel()
            {
                Password = "qwerty12345",
                Email = "Admin@gmail.com"
            };
            AdminClient client = new AdminClient();

            string token = client.Auth(adminAuthRequestModel);
            Assert.NotNull(token);
        }
    }
}