using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SharedLib.IServices
{
    public interface IDevicesService
    {
        Task CreateUserDeviceAsync(string userid);
        void AddDevice(string userid, Device device);
        void RemoveDevice(string userid, int deviceId);
        Task<Device> GetUserDevices(string userid);
    }
}
