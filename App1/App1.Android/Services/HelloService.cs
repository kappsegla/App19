using App1.Services;

namespace App1.Android.Services
{
    public class HelloService : IHelloService
    {
        public string GetMessage()
        {
            return "Hello from Android";
        }
    }
}