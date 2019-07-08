using SharedLib;
using SharedLib.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMinotaur.Services
{
    public class DevicesService : IDevicesService
    {
        public void AddDevice(string userid, Device device)
        {
            throw new NotImplementedException();
        }

        public async Task CreateUserDeviceAsync(string userid)
        {
            throw new NotImplementedException();
        }

        public async Task<Device> GetUserDevices(string userid)
        {
            throw new NotImplementedException();
        }

        public void RemoveDevice(string userid, int deviceId)
        {
            throw new NotImplementedException();
        }
    }
}
