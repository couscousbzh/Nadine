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
        ILogger _logger;
        HubConnection connection;

        public CounterModel(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
            _logger = _loggerFactory.CreateLogger("###Nadine### ");
        }

        public void OnGet()
        {
            Launch();            
        }

        public void Launch()
        {
            //await InitHub();
            //await FakeCounter();
        }

        public async Task<bool> InitHub()
        {
            _logger.LogDebug("InitHub...");

            try
            {
                connection = new HubConnectionBuilder()
                    .WithUrl("http://localhost:5000/counterhub")
                    .Build();

                await connection.StartAsync();

                Console.WriteLine("Hub connection started");
                _logger.LogDebug("Hub connection started");

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error : " + ex.Message);
                Console.WriteLine("Error : " + ex.Message);
                return false;
            }
        }
        public async Task FakeCounter()
        {
            _logger.LogDebug("FakeCounter starting");
            int counter = 0;

            for (int i = 0; i < 100; i++)
            {
                counter++;
                _logger.LogDebug("Counter = " + counter.ToString());

                try
                {
                    //logger.LogDebug("Debug");
                    //logger.LogInformation("Info");
                    //logger.LogWarning("Warning");
                    //logger.LogError("Error");
                    //logger.LogCritical("Critical");

                    await connection.InvokeAsync("CounterUpdate", counter.ToString());
                    await Task.Delay(1000);
                }
                catch (Exception ex)
                {
                    _logger.LogError("Error : " + ex.Message);
                    await Task.Delay(1000);
                }
            }


        }
    }
}
