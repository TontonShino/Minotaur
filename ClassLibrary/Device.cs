using System;
using System.Collections.Generic;

namespace SharedLibrary
{
    public class Device
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<IPAddrr> IPAddrrs { get; set; }
        public UserDevice UserDevice { get; set; }
        public string UserId { get; set; }
        
    }
}
