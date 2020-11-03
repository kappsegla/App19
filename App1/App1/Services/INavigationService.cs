using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1.Services
{
    public interface INavigationService
    {
        Task PushAsync(Page page);
        Task<Page> PopAsync();
    }
}