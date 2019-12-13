using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DemoApp.ViewModels;
using LightInject;

namespace DemoApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            var container = new ServiceContainer(new ContainerOptions { EnablePropertyInjection = false });
            container.RegisterFrom<CompositionRoot>();
            MainViewModel = container.GetInstance<ContainerViewModel>();
            DataContext = MainViewModel;
            InitializeComponent();
            MainViewModel.Initialize();

        }

        public ContainerViewModel MainViewModel { get; }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
        }
    }
}
