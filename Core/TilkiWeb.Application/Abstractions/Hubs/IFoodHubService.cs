using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TilkiWeb.Application.Abstractions.Hubs
{
    public interface IFoodHubService
    {
        Task FoodAddedMessageAsync(string message);
    }

}
