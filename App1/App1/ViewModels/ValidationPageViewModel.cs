using System.Windows.Input;
using App1.Services;
using App1.Validation;
using App1.Views;
using Xamarin.Forms;

namespace App1.ViewModels
{
    public class ValidationPageViewModel : BaseViewModel
    {
        public ValidationPageViewModel()
        {
            UserName = new ValidatableObject<string> {Value = ""};
            
            AddValidations();
            
            ValidateInput = new Command(async () =>
            {
                ValidateUserName();
            });
        }

        public ICommand ValidateInput { get; }

        
        private ValidatableObject<string> _userName;

        public ValidatableObject<string> UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
                OnPropertyChanged();
            }
        }

        public ICommand ValidateUserNameCommand => new Command(() => ValidateUserName());

        private void ValidateUserName()
        {
            _userName.Validate();
        }

        private void AddValidations()
        {
            _userName.Validations.Add(new IsNotNullOrEmptyRule<string>
            {
                ValidationMessage = "A username is required."
            });
            _userName.Validations.Add(new UserNameAtLeast5Characters<string>
            {
                ValidationMessage = "A username must be at least 5 characters."
            });
        }
    }
}