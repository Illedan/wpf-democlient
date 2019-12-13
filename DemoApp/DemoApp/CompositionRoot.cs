using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoApp.Service;
using DemoApp.ViewModels;
using LightInject;

namespace DemoApp
{
    class CompositionRoot : ICompositionRoot
    {
        public void Compose(IServiceRegistry serviceRegistry)
        {
            serviceRegistry.Register<MainViewModel>();
            serviceRegistry.Register<ContainerViewModel>();
            serviceRegistry.Register<IHeyService, HeyService>();
            serviceRegistry.Register<IPlugin, DefaultPlugin>();
            serviceRegistry.Register<IPlugin, LeetPlugin>("test");
            serviceRegistry.Register<IPlugin, LifePlugin>("test2");
        }
    }
}
