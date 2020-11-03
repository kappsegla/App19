using System.Net.Http;
using App1.Models;
using App1.Services;
using App1.ViewModels;
using Autofac;
using Xamarin.Forms;

namespace App1.Views
{
    //[XamlCompilation (XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
          //  Label1.BindingContext = Slider1;
          //  Label1.SetBinding(VisualElement.RotationProperty, "Value");
          this.BindingContext = AppContainer.Container.Resolve<MainPageViewModel>();
          //new MainPageViewModel(DependencyService.Resolve<IHelloService>(),new CatFactApi(new HttpClient())); 
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            //Add more code here
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }
    }
}