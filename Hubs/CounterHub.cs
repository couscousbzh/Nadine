using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nadine.Hubs
{
    public class CounterHub : Hub
    {
        public async Task CounterUpdate(string message)
        {
            await Clients.All.SendAsync("CounterUpdate", message);
        }
        
    }
}
