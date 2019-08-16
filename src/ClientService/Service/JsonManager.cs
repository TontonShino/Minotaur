using ClientService.IService;
using ClientService.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace ClientService.Service
{
    public class JsonManager : IJsonManager
    {
        public Device ToDevice(string json)
        {
            return JsonConvert.DeserializeObject<Device>(json);
        }

        public TokenValidation ToTokenValidation(string json)
        {
            return JsonConvert.DeserializeObject<TokenValidation>(json);
        }

        public string ToJson(object _object)
        {
            return JsonConvert.SerializeObject(_object);
        }
        public StringContent ToStringContent(object _object)
        {
            return new StringContent(JsonConvert.SerializeObject(_object), Encoding.UTF8, "application/json");
        }

        public DeviceRegisteredModel ToDeviceRegistered(string json)
        {
            return JsonConvert.DeserializeObject<DeviceRegisteredModel>(json); 
        }
    }
}