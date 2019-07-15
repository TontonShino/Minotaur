using Microsoft.AspNetCore.Components;
using SharedLib;
using SharedLib.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebMinotaur.Services
{
    public class DevicesService : IDevicesService
    {
        private HttpClient client;
        public DevicesService(HttpClient httpClient)
        {
            client = httpClient;
        }
        public void AddDevice(string userid, Device device)
        {

            throw new NotImplementedException();
        }

        public Task CreateUserDeviceAsync(string userid)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Device>> GetUserDevicesAsync(string userid)
        {
            return await client.GetJsonAsync<List<Device>>(client.BaseAddress+ "api/Devices/userdevices/" + userid);
        }

        public void RemoveDevice(string userid, int deviceId)
        {
            throw new NotImplementedException();
        }


    }
}
