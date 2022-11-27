using CleaningBackTesting.Client;
using CleaningBackTesting.RequestModels;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CleaningBackTesting
{
    public class Tests
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