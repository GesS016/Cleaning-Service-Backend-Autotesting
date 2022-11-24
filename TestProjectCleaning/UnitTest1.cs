using CleaningBackTesting.RequestModels;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TestProjectCleaning
{
    public class Tests
    {
        public void Test1()
        {
            AdminAuthRequestModel adminAuthRequestModel = new AdminAuthRequestModel()
            {
                Password = "qwerty12345",
                Email = "Admin@gmail.com"
            };
            Client client = new Client();
        }
    }
}