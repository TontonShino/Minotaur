using SharedLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Data;
using Microsoft.AspNetCore.Identity;
using System.Net.Http;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http.Extensions;

namespace Web.Services
{
    public class DevicesService
    {
        HttpClient client;
        string apiUrl = "";
        ApplicationDbContext db;
        
        public DevicesService(HttpClient httpClient)
        {
            this.client = httpClient;
        }
        public async Task CreateUserDeviceAsync(string userid)
        {
            Console.WriteLine($"Adresse URI {client.BaseAddress}");
            
            var ud = new UserDevice
            {
                Id = userid,
                CreationDate = DateTime.UtcNow
            };
             await client.SendJsonAsync(HttpMethod.Post, client.BaseAddress+"api/UserDevices", ud);
        }
        public void AddDevice(string userid)
        {

        }
        public void RemoveDevice(string userid)
        {

        }

        public async Task<UserDevice> GetUserDevices(string userid)
        {            
            return await client.GetJsonAsync<UserDevice>(client.BaseAddress+"api/UserDevices/" + userid);
        }
        public bool ExistUserData(string id)
        {

            return true;
        }
    }
}
