using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleClient
{
    public class RequestClient
    {
        private HttpClient httpClient;
        private readonly string BaseAddress = "https://localhost:44307/api/";
        public string token { get; set; }

        public RequestClient() { }
        public RequestClient(string token) { this.token = token; }
        public async Task<string> Login(Login login)
        {
            PrepareRequest();
            var content = new StringContent(JsonConvert.SerializeObject(login), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("Auth/login", content);
            return await response.Content.ReadAsStringAsync();
        }
        public async Task<string> RegisterNewDevice(DeviceRegisterModel model)
        {
            PrepareRequest();
            var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("Devices/",content);
            return await response.Content.ReadAsStringAsync();
        }
        public void PostState()
        {
            PrepareRequest();
        }
        private void SetUpBaseAddress()
        {
            httpClient.BaseAddress = new Uri(BaseAddress);
        }
        private void SetUpHeaderToken()
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }
        private void PrepareRequest()
        {
            httpClient = new HttpClient();
            SetUpBaseAddress();
            SetUpHeaderToken();
        }

    }
}
