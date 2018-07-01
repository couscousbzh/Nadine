using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Logging;

namespace Nadine.Pages
{
    public class CounterModel : PageModel
    {
         ILogger<CounterModel> _logger;

        HubConnection connection;
                   
        public async void OnGet()
        {
            await FakeCounter();
        }

        public async Task FakeCounter()
        {
            int counter=0;

            connection = new HubConnectionBuilder()
                .WithUrl("https://localhost:44317/ChatHub")
                .Build();  

            while(true)
            {
                counter++;
                
                await Task.Delay(1000);
                _logger.LogInformation( counter.ToString());
                try
                {
                    await connection.InvokeAsync("CounterUpdate", counter.ToString() );
                }
                catch (Exception ex)
                {                
                    _logger.LogError("Error : " + ex.Message );            
                }
            }



        }
    }
}
