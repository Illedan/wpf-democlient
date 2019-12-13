using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp.ViewModels
{
    public interface IPlugin
    {
        bool WantsToDoWork(string input);
        Task<string> DoWork(string input);
    }
}
