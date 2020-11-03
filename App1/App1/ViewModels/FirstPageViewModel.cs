using System.Windows.Input;
using App1.Services;
using App1.Views;
using Xamarin.Forms;

namespace App1.ViewModels
{
    public class FirstPageViewModel : BaseViewModel
    {
        
        public FirstPageViewModel(INavigationService navigation)
        {
            DoNavigation = new Command(async () =>
            { 
                await navigation.PushAsync(new SecondPage());
               //await Application.Current.MainPage.Navigation.PushAsync(new SecondPage());
            });
        }

        public ICommand DoNavigation { get; }
        
    }
}