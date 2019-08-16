using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientService.IService;
using ClientService.Service;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ClientService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddSingleton<IRequest, Request>();
                    services.AddSingleton<IDeviceConfiguration, DeviceConfiguration>();
                    services.AddSingleton<IJsonManager, JsonManager>();
                    services.AddHostedService<Worker>();
                });
    }
}
