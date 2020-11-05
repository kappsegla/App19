using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using App1.Services;
using App1.Utils;
using App1.Views;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace App1.ViewModels
{
    public class FirstPageViewModel : BaseViewModel
    {
        public FirstPageViewModel(INavigationService navigation, IXamarinEssentials essentials)
        {
            BatteryLevel = essentials.BatteryLevel;
            DoNavigation = new Command(async () =>
            { 
                await navigation.PushAsync(new SecondPage());
            });
        }

        private string _name="";
        
        public string Name
        {
            get => _name;
            set
            {
                System.Diagnostics.Debug.WriteLine("Some output from our code");
                if (value.Equals(_name)) return;
                _name = value;
                OnPropertyChanged();
            }
        }
        
        public ICommand DoNavigation { get; }

        private double _batteryLevel;
        public double BatteryLevel
        {
            get => _batteryLevel;
            set
            {
                if (value.Equals(_batteryLevel)) return;
                _batteryLevel = value;
                OnPropertyChanged();
            }
        }

        public int Add(int a, int b)
        {
            var numbers = new List<int> {a,b};
            return numbers.Sum();
        }
    }
}