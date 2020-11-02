using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App1.ViewModels;
using Autofac;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage(string text)
        {
            InitializeComponent();
            var viewModel = AppContainer.Container.Resolve<ItemDetailViewModel>();
            viewModel.Text = text;
            BindingContext = viewModel;
        }
    }
}