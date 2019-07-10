using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SharedLib.IRepositories
{
    public interface IDevicesRepository
    {
        Task<List<Device>> GetDevicesAsync(string userid);
        List<Device> GetDevices(string userid);
        Task<Device> GetDeviceAsync(string id);
        Device GetDevice(string id);
        Task<Device> AddDeviceAsync(Device device);
        Device AddDevice(Device device);
        Device UpdateDevice(Device device);
        Task<Device> UpdateDeviceAsync(Device device);
        Task DeleteDeviceAsync(string id);
        void DeleteDevice(string id);

    }
}
