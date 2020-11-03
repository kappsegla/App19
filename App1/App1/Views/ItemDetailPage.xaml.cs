using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App1.Models;
using App1.ViewModels;
using Autofac;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage(CatFact fact)
        {
            InitializeComponent();
            var viewModel = AppContainer.Container.Resolve<ItemDetailViewModel>();
            viewModel.Text = fact.Text;
            BindingContext = viewModel;
        }
    }
}