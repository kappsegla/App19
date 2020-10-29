using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using App1.Annotations;
using App1.Services;
using Xamarin.Forms;

namespace App1.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {

        private IHelloService _helloService;

        public MainPageViewModel(IHelloService helloService)
        {
            _helloService = helloService;
            text = _helloService.GetMessage();
            
            ButtonAction = new Command(execute: () =>
            {
                Text = "";
            },canExecute: () =>
            {
                return !text.Equals("");
            });
        }

        private string text = "Hej på dig!";
        
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
            ((Command)ButtonAction).ChangeCanExecute();
            //Add more ICommands here
        }
    }
}