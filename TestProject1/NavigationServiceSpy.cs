using System;
using System.Threading.Tasks;
using App1.Services;
using Xamarin.Forms;

namespace TestProject1
{
    public class NavigationServiceSpy : INavigationService
    {
        public bool PushAsyncCalled;
        public Page page;
        
        public Task PushAsync(Page page)
        {
            PushAsyncCalled = true;
            this.page = page;
            return Task.CompletedTask;
        }

        public Task<Page> PopAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}