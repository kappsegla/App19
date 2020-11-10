using System;
using App1.Bootstrap;
using App1.Views;
using Autofac;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

//[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace App1
{
    public partial class App : Application
    {
       public App(AppSetup setup)
        {
            InitializeComponent();
            // AppDomain.CurrentDomain.UnhandledException += (sender, args) => {
            //     System.Exception ex = (System.Exception)args.ExceptionObject;
            //     Console.WriteLine(ex);
            // };
           AppContainer.Container = setup.CreateContainer();
            
            //MainPage = new MainPage();
            //MainPage = new NavigationPage(new ItemsPage());
            MainPage = new ValidationPage();
            //MainPage = new NavigationPage (new FirstPage());
            //MainPage = new AppShell();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}