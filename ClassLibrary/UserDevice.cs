using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLibrary
{
    public class UserDevice
    {
        public string Id { get; set; }
        public DateTime CreationDate { get; set; }
        public List<Device> Devices { get; set; }
    }
}
