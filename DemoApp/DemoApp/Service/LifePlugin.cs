using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoApp.ViewModels;

namespace DemoApp.Service
{
    class LifePlugin : IPlugin
    {
        public Task<string> DoWork(string input)
        {
            return Task.FromResult("42");
        }

        public bool WantsToDoWork(string input)
        {
            return input.Contains("42");
        }
    }
}
