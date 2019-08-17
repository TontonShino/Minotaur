using ClientService.Models;

namespace ClientService.IService
{
    public interface IDeviceConfiguration
    {
         Device GetDeviceConfiguration();
         string ReadDeviceConfiguration();
         void SaveDeviceConfiguration(Device device);

    }
}