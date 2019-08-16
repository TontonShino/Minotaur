using System.IO;
using ClientService.IService;
using ClientService.Models;


namespace ClientService.Service
{
    public class DeviceConfiguration : IDeviceConfiguration
    {
        private readonly IJsonManager _jsonManager;
        private string clientSettings = "client.json";
        private StreamReader streamReader;
        private StreamWriter streamWriter;

        public DeviceConfiguration(IJsonManager jsonManager){_jsonManager = jsonManager;}

        public string ReadDeviceConfiguration()
        {
            streamReader = new StreamReader(clientSettings);
            var data = streamReader.ReadToEnd();
            streamReader.Close();
            return data;
        }
        public Device GetDeviceConfiguration()
        {
            var data = ReadDeviceConfiguration();
            return _jsonManager.ToDevice(data);            
        }

        public void SaveDeviceConfiguration(Device device)
        {
            streamWriter = new StreamWriter(clientSettings);
            var json = _jsonManager.ToJson(device);
            streamWriter.Write(json);
            streamWriter.Close();
        }
    }
}