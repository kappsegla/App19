using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1.Services
{
    public class NavigationService : INavigationService
    {
        public async Task PushAsync(Page page)
        {
            await Application.Current.MainPage.Navigation.PushAsync(page);
        }

        public async Task<Page> PopAsync()
        {
            return await Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}