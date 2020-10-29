using System.Windows.Input;
using App1.Services;
using Xamarin.Forms;

namespace App1.ViewModels
{
    public class MainPageViewModel : BaseViewModel, IViewModel
    {


        private IHelloFormsService _formsService;
        public MainPageViewModel(IHelloFormsService formsService)
        {
            _formsService = formsService;
            text = _formsService.GetHelloFormsText();
            
            ButtonAction = new Command(execute: () =>
            {
                Text = "";
            },canExecute: () =>
            {
                return !text.Equals("");
            });
            OnFavoriteSwipeItemInvoked = new Command(() => {});
            OnDeleteSwipeItemInvoked = new Command(() => {});
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
        public ICommand OnFavoriteSwipeItemInvoked { private set; get; } 
        public ICommand OnDeleteSwipeItemInvoked { private set; get; }
        
        
        private void RefreshCanExecute()
        {
            ((Command)ButtonAction).ChangeCanExecute();
            ((Command)OnFavoriteSwipeItemInvoked).ChangeCanExecute();
            ((Command)OnDeleteSwipeItemInvoked).ChangeCanExecute();
            //Add more ICommands here
        }
    }
}