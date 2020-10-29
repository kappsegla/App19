using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using App1.Annotations;
using App1.Models;
using App1.Services;
using Xamarin.Forms;

namespace App1.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        private IHelloService _helloService;
        private CatFactApi _catFactApi;

        public MainPageViewModel(IHelloService helloService, CatFactApi catFactApi)
        {
            _helloService = helloService;
            _catFactApi = catFactApi;
            text = _helloService.GetMessage();

            ButtonAction = new Command(execute: async () =>
            {
                var fact = await _catFactApi.GetRandomCatFact();
                Text = fact.Text;
            }, canExecute: () => { return !text.Equals(""); });
        }

        private string text = "";

        public string Text
        {
            get => text;
            set
            {
                if (text == value) return;
                text = value;
                OnPropertyChanged();
                RefreshCanExecute();
            }
        }

        public ICommand ButtonAction { private set; get; }

        private void RefreshCanExecute()
        {
            ((Command) ButtonAction).ChangeCanExecute();
            //Add more ICommands here
        }
    }
}