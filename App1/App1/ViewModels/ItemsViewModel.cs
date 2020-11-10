using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using App1.Models;
using App1.Utils;
using App1.Views;
using Autofac;
using Xamarin.Forms;

namespace App1.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        private CatFactApi _factApi;

        private CatFact _selectedItem;
        
        public ObservableCollection<CatFact> Items { get; }

        public ICommand LoadItemsCommand { get; }

        public Command<CatFact> ItemTapped { get; }

        public ItemsViewModel(CatFactApi factApi)
        {
            _factApi = factApi;
            //Items = new RangeObservableCollection<CatFact>();
            Items = new ObservableCollection<CatFact>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            ItemTapped = new Command<CatFact>(OnItemSelected);
            SelectionChanged = new Command(()=> OnItemSelected(SelectedItem));
        }

        private async void OnItemSelected(CatFact fact)
        {
            if (fact == null)
                return;
            
            //Navigate
             var secondPage = new ItemDetailPage(fact);
             await Application.Current.MainPage.Navigation.PushAsync(secondPage);
            //Shell
            //await Shell.Current.GoToAsync($"catdetail?text={fact.Text}");
        }

        public CatFact SelectedItem
        {
            get => _selectedItem;
            set
            {
               _selectedItem = value;
                OnPropertyChanged();
            }
        }

        public ICommand SelectionChanged { get; }
        
        private async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;
            var items = await _factApi.GetCatFactsAsync();
            Items.Clear();
            foreach (var item in items.Take(20))
            {
                 Items.Add(item);
            }

            IsBusy = false;
        }
    }
}