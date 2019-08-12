using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ConsoleClient
{
    public class DataConfig
    {
        private string loginSettings = "login.json";
        private string clientSettings = "client.json";
        private StreamReader streamReader;
        private StreamWriter streamWriter;
        public DataConfig()
        {

        }
        public bool LoginSettingsExists()
        {
            return File.Exists(loginSettings);
        }
        public bool ClientSettingsExists()
        {
            return File.Exists(clientSettings);
        }
        public void SaveLoginsSettings(string json)
        {
            streamWriter = new StreamWriter(loginSettings);
            streamWriter.Write(json);
            streamWriter.Close();
        }
        public string LoadLoginsSettings()
        {
            streamReader = new StreamReader(loginSettings);
            var data = streamReader.ReadToEnd();
            return data;
        }
        public void SaveClientSettings(string json)
        {
            streamWriter = new StreamWriter(clientSettings);
            streamWriter.Write(json);
            streamWriter.Close();
        }
        public string LoadClientSettings()
        {
            streamReader = new StreamReader(clientSettings);
            var data = streamReader.ReadToEnd();
            return data;
        }
       
    }
}
