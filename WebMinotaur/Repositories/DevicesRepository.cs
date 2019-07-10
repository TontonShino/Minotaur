using SharedLib;
using SharedLib.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMinotaur.Repositories
{
    public class DevicesRepository : IDevicesRepository
    {
        public Device AddDevice(Device device)
        {
            throw new NotImplementedException();
        }

        public Task<Device> AddDeviceAsync(Device device)
        {
            throw new NotImplementedException();
        }

        public void DeleteDevice(string id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteDeviceAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Device GetDevice(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Device> GetDeviceAsync(string id)
        {
            throw new NotImplementedException();
        }

        public List<Device> GetDevices(string userid)
        {
            throw new NotImplementedException();
        }

        public Task<List<Device>> GetDevicesAsync(string userid)
        {
            throw new NotImplementedException();
        }

        public Device UpdateDevice(Device device)
        {
            throw new NotImplementedException();
        }

        public Task<Device> UpdateDeviceAsync(Device device)
        {
            throw new NotImplementedException();
        }
    }
}
