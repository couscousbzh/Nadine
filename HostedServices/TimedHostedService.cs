using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Nadine
{
    internal class TimedHostedService : IHostedService, IDisposable
    {
        private readonly ILogger _logger;
        private Timer _timer;

        private GpioWorker _myWorker;

        public TimedHostedService(ILogger<TimedHostedService> logger)
        {
            _logger = logger;

            _myWorker = new GpioWorker();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Timed Background Service is starting.");
            
            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromMilliseconds(1));

            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            //_logger.LogInformation("Timed Background Service is working.");
            //Console.WriteLine("Timed Background Service is working : " + DateTime.Now.ToString());

            _myWorker.ReadGPIO();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Timed Background Service is stopping.");

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }

}