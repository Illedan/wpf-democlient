using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoApp.ViewModels;

namespace DemoApp.Service
{
    class LeetPlugin : IPlugin
    {
        public Task<string> DoWork(string input)
        {
            return Task.FromResult("1337");
        }

        public bool WantsToDoWork(string input)
        {
            return input.Contains("1337");
        }
    }
}
