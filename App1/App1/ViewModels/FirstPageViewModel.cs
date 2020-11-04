using System;
using System.Windows.Input;
using App1.Services;
using App1.Views;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace App1.ViewModels
{
    public class FirstPageViewModel : BaseViewModel
    {
        private double _level;

        public FirstPageViewModel(INavigationService navigation)
        {
            Level = Battery.ChargeLevel;
            // Register for battery changes, be sure to unsubscribe when needed
            Battery.BatteryInfoChanged += Battery_BatteryInfoChanged;
            System.Diagnostics.Debug.WriteLine(Level);
            
            DoNavigation = new Command(async () =>
            {
                await navigation.PushAsync(new SecondPage());
            });
        }

        public ICommand DoNavigation { get; }

        public double Level
        {
            get => _level;
            set
            {
                if (_level.Equals(value)) return;
                _level = value;
                OnPropertyChanged();
            }
        }
        
        void Battery_BatteryInfoChanged(object sender, BatteryInfoChangedEventArgs   e)
        {
            var level = Level = e.ChargeLevel;
            var state = e.State;
            var source = e.PowerSource;
            Console.WriteLine($"Reading: Level: {level}, State: {state}, Source: {source}");
        }
    }
}