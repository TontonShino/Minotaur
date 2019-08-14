using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Text;
using Newtonsoft.Json.Converters;
using System.Globalization;
using System.IO;

namespace ConsoleClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            RequestClient requestClient;
            DataConfig dataConfig = new DataConfig();
            ClientConfig clientConfig;
            LoginVieModel login;

            //Check if config file
            if(!dataConfig.ClientSettingsExists() )
            {

                var jsonClient = JsonConvert.SerializeObject(new ClientConfig());
                dataConfig.SaveClientSettings(jsonClient);
                Console.WriteLine("config Not found");


            }
            if (!dataConfig.LoginSettingsExists())
            {
                Console.WriteLine("Not existing logins");
                //Create login file
                var jsonlogin = JsonConvert.SerializeObject(new LoginVieModel());
                dataConfig.SaveLoginsSettings(jsonlogin);
            }

                //Try extract (deserialize) clientsettings
                var tempClientConf = dataConfig.LoadClientSettings();
                clientConfig = JsonConvert.DeserializeObject<ClientConfig>(tempClientConf);

                var tempLoginConf = dataConfig.LoadLoginsSettings();
                login = JsonConvert.DeserializeObject<LoginVieModel>(tempLoginConf);


                  //If no token try to connect
            if (clientConfig.TokenValidation == null)
            {
                requestClient = new RequestClient();

                var res = await requestClient.Login(login);
                clientConfig.TokenValidation = JsonConvert.DeserializeObject<TokenValidation>(res);
                Console.WriteLine(res);

                clientConfig.Name = DeviceInfo.GetMachineName();
                clientConfig.Description = DeviceInfo.GetMachineDescription();

                requestClient.token = clientConfig.TokenValidation.token;

                var deviceString = await requestClient.RegisterNewDevice(
                    new DeviceRegisterModel
                    {
                        name =clientConfig.Name, description = clientConfig.Description
                    });

                var device = JsonConvert.DeserializeObject<DeviceViewModel>(deviceString);
                Console.WriteLine($"deviceId = {device.id} UserId = {device.appUserId}");

                clientConfig.Id = device.id;
                clientConfig.appUserId = device.appUserId;

                var clientConfJson = JsonConvert.SerializeObject(clientConfig);
                dataConfig.SaveClientSettings(clientConfJson);
            }
            requestClient = new RequestClient(clientConfig.TokenValidation.token);
            while(true)
            {
                var deviceState = new DeviceState
                {
                    deviceId = clientConfig.Id,
                    ip = DeviceInfo.GetMachineIPAddrress()
                };

                var status = await requestClient.PostState(deviceState);
                Console.WriteLine($"Request status on posting device state {status.ToString()}");
                System.Threading.Thread.Sleep(500000);
            }
            //Register new device
            
            //Request token

            //Main loop


                //Try posting

                //if ok 
                //continue posting

                //else
                //ask new one
                //save it
            

        }
    }
}
