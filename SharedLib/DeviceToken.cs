using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLib
{
    public class DeviceToken
    {
        public string Id { get; set; }
        public DateTime ExpirationDate { get; set; }
        public DateTime CreationDate { get; set; }
        public Device Device { get; set; }
        public string DeviceId { get; set; }
        public bool Enabled { get; set; }
    }
}
