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
          //this.BindingContext = new MainPageViewModel();
          this.BindingContext = AppContainer.Container.Resolve<MainPageViewModel>();
        }
    }
}