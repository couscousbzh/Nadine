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
        ILoggerFactory _loggerFactory;

        HubConnection connection;

        public CounterModel(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }

        public async void OnGet()
        {
            await FakeCounter();
        }

        public async Task FakeCounter()
        { 
            var logger = _loggerFactory.CreateLogger("###Nadine### ");

            logger.LogDebug("FakeCounter starting");

            try
            {
                //logger.LogDebug("Debug");
                //logger.LogInformation("Info");
                //logger.LogWarning("Warning");
                //logger.LogError("Error");
                //logger.LogCritical("Critical");
                                
                int counter = 0;

                connection = new HubConnectionBuilder()
                    .WithUrl("https://localhost:44377/counterhub")
                    .Build();

                await connection.StartAsync();

                for (int i = 0 ; i< 100 ; i++)
                {
                    counter++;

                    logger.LogDebug("Counter = " + counter.ToString());

                    await connection.InvokeAsync("CounterUpdate", counter.ToString());

                    await Task.Delay(1000);
                }
            }
            catch (Exception ex)
            {
                logger.LogError("Error : " + ex.Message);
            }


        }
    }
}
