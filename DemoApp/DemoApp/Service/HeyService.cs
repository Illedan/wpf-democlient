using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoApp.Models;
using DemoApp.ViewModels;

namespace DemoApp.Service
{
    public class HeyService : IHeyService
    {
        public async Task<string> GetHey()
        {
            await Task.Delay(500);
            return "Hheeyy";
        }

        public Task<ItemModel[]> GetModels()
        {
            var items = new List<ItemModel>();
            for(var i = 0; i < 10000; i++)
            {
                items.Add(new ItemModel { Content = "testing " + i + " 2" });
            }
            return Task.FromResult(items.ToArray());
        }

        public async Task PostSelected(ItemModel itemModel)
        {
            await Task.Delay(5);
            itemModel.IsContagious = true;
        }
    }
}
