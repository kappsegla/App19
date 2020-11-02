using App1.Models;
using Xamarin.Forms;

namespace App1.ViewModels
{
    [QueryProperty("Text", "text")]
    public class ItemDetailViewModel : BaseViewModel
    {
        private string _text = "";
        
        public string Text
        {
     
            get => _text;
            set
            {
                if (_text.Equals(value)) return;
                _text = value;
                OnPropertyChanged();
            }
     
        }
        
        
    }
}