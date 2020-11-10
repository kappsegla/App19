using System.Net.Http;
using App1.Models;
using App1.Services;
using App1.ViewModels;
using Autofac;
using Xamarin.Forms;

namespace App1.Views
{
    //[XamlCompilation (XamlCompilationOptions.Compile)]
    public partial class ValidationPage : ContentPage
    {
        public ValidationPage()
        {
            InitializeComponent();
            BindingContext = new ValidationPageViewModel();
        }
    }
}