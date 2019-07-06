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
        

        public async Task CreateUserDeviceAsync(string userid)
        {
            client = new HttpClient();
            var ud = new UserDevice
            {
                Id = userid,
                CreationDate = DateTime.UtcNow
            };
             await client.SendJsonAsync(HttpMethod.Post, "api/UserDevices", ud);
        }
        public void AddDevice(string userid)
        {

        }
        public void RemoveDevice(string userid)
        {

        }

        public async Task<UserDevice> GetUserDevices(string userid)
        {
            client = new HttpClient();
            return await client.GetJsonAsync<UserDevice>("api/UserDevices/" + userid);
        }
        public bool ExistUserData(string id)
        {

            return true;
        }
    }
}
