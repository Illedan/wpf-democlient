using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoApp.Models;

namespace DemoApp.ViewModels
{
    public class ItemViewModel : ViewModelBase
    {
        private readonly ItemModel itemModel;

        public ItemViewModel(ItemModel itemModel)
        {
            this.itemModel = itemModel;
        }

        public bool IsContagious { get => itemModel.IsContagious; }

        public string Content { get => itemModel.Content; set => itemModel.Content = value; }

        public ItemModel GetModel() => itemModel;

        public void OnContagiousChanged()
        {
            OnPropertyChanged(nameof(IsContagious));
        }
    }
}
