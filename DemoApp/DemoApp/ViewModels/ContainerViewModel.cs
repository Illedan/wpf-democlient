using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp.ViewModels
{
    public class ContainerViewModel : ViewModelBase, IContentViewModel
    {
        private readonly MainViewModel mainViewModel;
        private object content;

        public ContainerViewModel(MainViewModel mainViewModel)
        {
            this.mainViewModel = mainViewModel;
        }

        public object Content { get => content; set => Set(ref content, value); }

        public async void Initialize()
        {
            Content = mainViewModel;
            await mainViewModel.Initialize(this);
        }
    }

    public interface IContentViewModel
    {
        object Content { get; set; }
    }
}
