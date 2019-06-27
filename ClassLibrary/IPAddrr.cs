using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class IPAddrr
    {
        public int Id { get; set; }
        public string Address { get; set; }

        public DateTime Record { get; set; }
        public int DeviceId { get; set; }
        public Device Device { get; set; }

    }
}
