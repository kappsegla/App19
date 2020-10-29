using App1.Services;

namespace App1.iOS.Services
{
    public class HelloService :IHelloService
    {
        public string GetMessage()
        {
            return "iOS here!!!";
        }
    }
}