using App1.Services;

namespace App1.Android.Services
{
    public class HelloFormsService : IHelloFormsService 
    {
        public string GetHelloFormsText() 
        {
            return "Hello Android Forms!";
        }
    }
}