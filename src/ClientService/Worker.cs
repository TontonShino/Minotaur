using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ClientService.IService;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ClientService.Models;

namespace ClientService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private IConfiguration _configuration;
        private IDeviceConfiguration _deviceConfiguration;
        private IJsonManager _jsonManager;
        private IRequest _request;
        private Device myDevice;

        public Worker(ILogger<Worker> logger,
        IConfiguration configuration,
        IDeviceConfiguration deviceConfiguration,
        IJsonManager jsonManager,
        IRequest request)
        {
            _configuration = configuration;
            _logger = logger;
            _deviceConfiguration = deviceConfiguration;
            _jsonManager = jsonManager;
            _request = request;
        }
        private async Task Login()
        {
            var result = await _request.Login();
            myDevice.tokenValidation = result; //Getting token
        }
        private async Task RegisterDevice()
        {
            myDevice.Name = DeviceInfo.GetMachineName();
            myDevice.Description = DeviceInfo.GetMachineDescription();
            var deviceToRegister = new DeviceRegisterModel
            {
                Name = myDevice.Name,
                Description = myDevice.Description
            };
            var result = await _request.RegisterNewDevice(deviceToRegister);
            myDevice.Id = result.id;
            myDevice.appUserId = result.appUserId;

        }
        private async Task PostState()
        {
            var deviceState = new DeviceState
            {
                deviceId = myDevice.Id,
                ip = DeviceInfo.GetMachineIPAddrress()
            };
            Console.WriteLine($"device state : {deviceState.ip}, {DateTime.UtcNow} {deviceState.deviceId}");
            await _request.PostState(deviceState);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            myDevice = _deviceConfiguration.GetDeviceConfiguration();
            Console.WriteLine($"Device :{myDevice.Id} {myDevice.Description} {myDevice.appUserId}");
           
            if(myDevice.tokenValidation.token == ""  || myDevice.tokenValidation.expiration < DateTime.UtcNow)
            {
                try
                {
                    await Login();


                    //if id == null  (unregistered device)
                    if(myDevice.Id == "")
                    {
                        await RegisterDevice();
                    }
                    _deviceConfiguration.SaveDeviceConfiguration(myDevice);
                    
                    
                }
                catch (Exception e)
                {
                    Console.WriteLine($"{e.ToString()}");
                }

            }

            Console.WriteLine($"Token value = {myDevice.tokenValidation.token} ");
            Console.WriteLine($"Token Exipration = {myDevice.tokenValidation.expiration} ");
            
            while (!stoppingToken.IsCancellationRequested)
            {

                await PostState();
                Console.WriteLine($"Next tick in 15 secs");

                await Task.Delay(TimeSpan.FromSeconds(15), stoppingToken);
            }
        }
    }
}
