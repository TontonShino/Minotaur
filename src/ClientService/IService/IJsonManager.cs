using ClientService.Models;
using ClientService.Service;
using System.Net.Http;

namespace ClientService.IService
{
    public interface IJsonManager
    {
        Device ToDevice(string json);
        string ToJson(object _object);
        TokenValidation ToTokenValidation(string json);
        DeviceRegisteredModel ToDeviceRegistered(string json);
        StringContent ToStringContent(object _object);
    }
}