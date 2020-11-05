using Xamarin.Essentials;

namespace App1.Utils
{
    public class XamarinEssentials : IXamarinEssentials
    {
        public double BatteryLevel { get => Battery.ChargeLevel; }
    }
}