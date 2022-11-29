using CleaningBackTesting.Client;
using CleaningBackTesting.RequestModels;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CleaningBackTesting
{
    public class CreateOrderTest
    {
        [Test]
        public void CreateOrderTest1()
        {
            AuthRequestModel adminAuthRequestModel = new AuthRequestModel()
            {
                Password = "qwerty12345",
                Email = "Admin@gmail.com"
            };
            AdminClient client = new AdminClient();

            string token 
        }
    }
}