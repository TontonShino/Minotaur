using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Text;
using Newtonsoft.Json.Converters;
using System.Globalization;

namespace ConsoleClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJiZGFuc29rb0BnbWFpbC5jb20iLCJqdGkiOiIxNTJmMjRkNi0yZTViLTQxZDctYmI5ZS1mZWM0YzBjMDVmMDMiLCJleHAiOjE1NzI1MTQ2NzIsImlzcyI6Imh0dHA6Ly9taW5vdGF1ci5mciIsImF1ZCI6Imh0dHA6Ly9taW5vdGF1ci5mciJ9.LKaRWjRwtJi-iRJw5yCIZ20BXnWivWZ54YWnQtSKfBE";

            //Check if config already Exist
            var httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:44307/api/"),
            };
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);


            var data = new LoginModel
            {
                username = "bdansoko@gmail.com",
                password = "P@$$word92220"
            };
            var stringContent = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            var json = JsonConvert.SerializeObject(data);

            var res = await httpClient.PostAsync("Auth/login", stringContent);
            Console.WriteLine($"Response: \n {await res.Content.ReadAsStringAsync()}");
            string tk = await res.Content.ReadAsStringAsync();
            var tokenResponse = TokenResponse.FromJson(tk);
            



            string name = Environment.MachineName;
            Console.WriteLine($"This computer name is: {name}");
        }

    }
    [Serializable]
    public class LoginModel
    {

        public string username { get; set; }
        public string password { get; set; }

    }


    public partial class TokenResponse
    {
        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("expiration")]
        public DateTimeOffset Expiration { get; set; }
    }

    public partial class TokenResponse
    {
        public static TokenResponse FromJson(string json) => JsonConvert.DeserializeObject<TokenResponse>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this TokenResponse self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
