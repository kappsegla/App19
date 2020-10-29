using App1.Services;

namespace App1.iOS.Services
{
    public class HelloFormsService : IHelloFormsService 
    {
        public string GetHelloFormsText() 
        {
            return "Hello iOS Forms!";
        }
    }
}