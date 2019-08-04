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
            #region TEST
            //var token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJ0b250b25AaGlyb3NvZnQuY29tIiwianRpIjoiNzRmNzNhYzMtMWQzMi00M2Q0LWEzZWYtN2U1YTc4YTFhODRiIiwiZXhwIjoxNTcyNzk1MTIwLCJpc3MiOiJodHRwOi8vbWlub3RhdXIuZnIiLCJhdWQiOiJodHRwOi8vbWlub3RhdXIuZnIifQ.ha7HSpiL_3MPJGQOO01eSQuVmo6OPR0EXhAkzaMo82s";
            //var httpClient = new HttpClient
            //{
            //    BaseAddress = new Uri("https://localhost:44307/api/"),
            //};
            //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);


            //var data = new
            //{
            //    username = "tonton@hirosoft.com",
            //    password = "P@$$word75"
            //};

            //var stringContent = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            //var json = JsonConvert.SerializeObject(data);

            //var res = await httpClient.PostAsync("Auth/login", stringContent);
            //Console.WriteLine($"Response: \n {await res.Content.ReadAsStringAsync()}");
            //string tk = await res.Content.ReadAsStringAsync();
            //var tokenResponse = TokenResponse.FromJson(tk);


            //string name = Environment.MachineName;
            //Console.WriteLine($"This computer name is: {name}");
            #endregion TEST

            //Check if config already Exist

            string file = "Data/config.txt";

            var existsFile = File.Exists(file);
            Console.Write($"file exists {existsFile}");
            if(existsFile)
            {
                //try to extract token

                //compare the expiration date

                
            }

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
