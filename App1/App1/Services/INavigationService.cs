using System.Threading.Tasks;
using App1.ViewModels;
using Xamarin.Forms;

namespace App1.Services
{
    public interface INavigationService
    {
        Task PushAsync(Page page);
        Task<Page> PopAsync();
    }
}