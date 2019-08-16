using ClientService.IService;
using ClientService.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ClientService.Service
{
    public class Request : IRequest
    {
        private readonly IDeviceConfiguration _deviceConfiguration;
        private readonly IJsonManager _jsonManager;
        private readonly IConfiguration _configuration;
        private HttpClient httpClient = new HttpClient();

        public string token { get; set; }
        public Request(IConfiguration configuration, 
            IJsonManager jsonManager,
            IDeviceConfiguration deviceConfiguration) 
        { 
            _configuration = configuration;
            _jsonManager = jsonManager;
            _deviceConfiguration = deviceConfiguration;
            SetUpBaseAddress();
        }
        public async Task<TokenValidation> Login()
        {
            
            var login = GetLogin();
            var content = _jsonManager.ToStringContent(login);
            var response = await httpClient.PostAsync("Auth/login",content);
            var tokenValidationStrings = await response.Content.ReadAsStringAsync();
            return _jsonManager.ToTokenValidation(tokenValidationStrings) ;
        }

        public async Task<HttpStatusCode> PostState(DeviceState model)
        {
            AttachToken();
            var content = _jsonManager.ToStringContent(model);
            var response = await httpClient.PostAsync("InfoIp/", content);
            return response.StatusCode;
        }

        public async Task<DeviceRegisteredModel> RegisterNewDevice(DeviceRegisterModel model)
        {
            AttachToken();
            var content = _jsonManager.ToStringContent(model);
            var response = await httpClient.PostAsync("Devices/", content);
            var deviceRegisteredStrings = await response.Content.ReadAsStringAsync();
            return _jsonManager.ToDeviceRegistered(deviceRegisteredStrings);
        }
        private void SetUpBaseAddress()
        {
            var baseAddress =  _configuration.GetSection("server-addrr").Value;
            httpClient.BaseAddress = new Uri(baseAddress);
        }
        private void AttachToken()
        {
            token = _deviceConfiguration.GetDeviceConfiguration().tokenValidation.token;
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }
        private LoginModel GetLogin()
        {
            return new LoginModel
            {
                username = _configuration.GetSection("login:username").Value,
                password = _configuration.GetSection("login:password").Value
            };
        }

    }
}
