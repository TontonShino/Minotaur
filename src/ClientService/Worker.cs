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
        private IDeviceConfiguration _deviceConfiguration;
        private IRequest _request;
        private Device myDevice;

        public Worker(ILogger<Worker> logger,
        IDeviceConfiguration deviceConfiguration,
        IRequest request)
        {
            _logger = logger;
            _deviceConfiguration = deviceConfiguration;
            _request = request;
        }
        private async Task Login()
        {
            var result = await _request.Login();
            _logger.LogInformation("Login result : ");
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
            _logger.LogInformation("Register device result:",result);
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
            _logger.LogInformation($"device state send to the server: {deviceState.ip}, {DateTime.UtcNow} {deviceState.deviceId}");
            await _request.PostState(deviceState);
        }

        private bool TokenExpired()
        {
            return myDevice.tokenValidation.expiration < DateTime.UtcNow ;
        }
        private bool TokenExists()
        {
            return myDevice.tokenValidation.token != "" || myDevice.tokenValidation.token != null;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            myDevice = _deviceConfiguration.GetDeviceConfiguration();
           
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
                    _logger.LogInformation($"{e.ToString()}");
                }

            }
           
            while (!stoppingToken.IsCancellationRequested)
            {
                if(TokenExpired())
                {
                    await Login();
                }
                await PostState();

                await Task.Delay(TimeSpan.FromSeconds(15), stoppingToken);
            }
        }
    }
}
