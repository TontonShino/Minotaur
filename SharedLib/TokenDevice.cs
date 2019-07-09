using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLib
{
    public class TokenDevice
    {
        public string Id { get; set; }
        public DateTime ExpirationDate { get; set; }
        public DateTime CreationDate { get; set; }
        public Device Device { get; set; }
        public int DeviceId { get; set; }
    }
}
