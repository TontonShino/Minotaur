using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLib
{
    public class InfoIP
    {
        public int Id { get; set; }
        public string Ip { get; set; }
        public DateTime Record { get; set; }
        public int DeviceId { get; set; }
        public Device Device { get; set; }

    }
}
