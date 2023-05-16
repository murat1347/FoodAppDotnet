using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TilkiWeb.Application.Abstractions.Hubs;

namespace TilkiWeb.Persistence.Services.Hubs
{
    public class FoodHubService : IFoodHubService
    {
        readonly IHubContext<FoodHub> _hubContext;

        public FoodHubService(IHubContext<FoodHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task FoodAddedMessageAsync(string message)
        {
            await _hubContext.Clients.All.SendAsync("receiveProductAddedMessage", message);
        }
    }
}
