using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Nadine
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // var host = new HostBuilder()
            //     .ConfigureHostConfiguration(configHost =>
            //     {                    
            //         configHost.SetBasePath(Directory.GetCurrentDirectory());
            //         configHost.AddJsonFile("hostsettings.json", optional: true);
            //         configHost.AddEnvironmentVariables(prefix: "PREFIX_");
            //         configHost.AddCommandLine(args);
            //     })
            //     .ConfigureAppConfiguration((hostContext, configApp) =>
            //     {
            //         configApp.SetBasePath(Directory.GetCurrentDirectory());
            //         configApp.AddJsonFile("appsettings.json", optional: true);
            //         configApp.AddJsonFile($"appsettings.{hostContext.HostingEnvironment.EnvironmentName}.json", optional: true);
            //         configApp.AddEnvironmentVariables(prefix: "PREFIX_");
            //         configApp.AddCommandLine(args);
            //     })
            //     .ConfigureServices((hostContext, services) =>
            //     {
            //         services.AddLogging();
            //         services.AddHostedService<TimedHostedService>();
            //     })
            //     ;
                        
            // host.Build().RunAsync();

            CreateWebHostBuilder(args).Build().Run();            
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
