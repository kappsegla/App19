using App1.Android.Services;
using App1.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(HelloService))]
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