using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoApp.Models;

namespace DemoApp.Service
{
    public interface IHeyService
    {
        Task<string> GetHey();
        Task PostSelected(ItemModel itemModel);
        Task<ItemModel[]> GetModels();
    }
}
