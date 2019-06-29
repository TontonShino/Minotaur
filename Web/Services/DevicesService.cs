using SharedLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Data;
using Microsoft.AspNetCore.Identity;
using System.Net.Http;

namespace Web.Services
{
    public class DevicesService
    {
        HttpClient client;
        string apiUrl = "";

        public void CreateUserDevice(string userid)
        {

        }
        public void AddDevice(string userid)
        {

        }
        public void RemoveDevice(string userid)
        {

        }

        
        public bool ExistUserData(int id)
        {
            return true;
        }
    }
}
