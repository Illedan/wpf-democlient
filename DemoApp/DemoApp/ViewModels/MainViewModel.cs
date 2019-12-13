using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using DemoApp.Models;
using DemoApp.Service;

namespace DemoApp.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IHeyService heyService;
        private readonly IPlugin[] plugins;
        private readonly DefaultPlugin defaultPlugin;

        private IContentViewModel contentViewModel;

        private string test = "initial";
        private ItemViewModel selectedItem;
        private string filter = string.Empty;

        public MainViewModel(IHeyService heyService, IEnumerable<IPlugin> plugins)
        {
            this.heyService = heyService;
            this.plugins = plugins.ToArray();
            defaultPlugin = plugins.OfType<DefaultPlugin>().First();
            Command = new RelayCommand(o => DoStuff());
        }

        public bool Contains(object de)
        {
            var vm = (ItemViewModel) de;
            return vm.Content.Contains(Filter);
        }

        public string Filter { get => filter; set  {
                filter = value;
                OnFilter();
            }
        }

        public ICollectionView Items { get; }

        public ICommand Command { get; }

        public void OnFilter()
        {
            Items.Refresh();
        }

        public async void DoStuff()
        {
            try
            {
                contentViewModel.Content = "HALLO";
                Test = await heyService.GetHey();
            }
            catch(Exception e)
            {

            }
        }

        public async void PostModel(ItemViewModel selectedItemViewModel)
        {
            try
            {
                //await heyService.PostSelected(selectedItemViewModel.GetModel());
                //selectedItemViewModel.OnContagiousChanged();
                var selectedPlugin = plugins.FirstOrDefault(p => p.WantsToDoWork(selectedItemViewModel.Content)) ?? defaultPlugin;
                Test = await selectedPlugin.DoWork(selectedItemViewModel.Content);

            }
            catch(Exception e)
            {

            }
        }

        public async Task Initialize(IContentViewModel contentViewModel)
        {
            this.contentViewModel = contentViewModel;
            try
            {
                Test = await heyService.GetHey();
                var models = await heyService.GetModels();

                //var items = new ObservableCollection<ItemViewModel>();
                //for(var i = 0; i < 10000; i++)
                //{
                //    items.Add(new ItemViewModel(new ItemModel { Content = "testing " + i + " 2" }));
                //}
                //Items = CollectionViewSource.GetDefaultView(items);
                //Items.Filter = new Predicate<object>(Contains);

            }
            catch(Exception e)
            {

            }
        }

        public string Test
        {
            get => test; set
            {
                this.Set(ref test, value);
            }
        }

        public ItemViewModel SelectedItem
        {
            get => selectedItem; set
            {
                selectedItem = value;
                PostModel(value);
            }
        }
    }
}
