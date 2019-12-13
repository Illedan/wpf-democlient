using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoApp.ViewModels;

namespace DemoApp.Service
{
    class DefaultPlugin : IPlugin
    {
        public Task<string> DoWork(string input)
        {
            return Task.FromResult("Default");
        }

        public bool WantsToDoWork(string input)
        {
            return false;
        }
    }
}
