using System;
using System.Collections.Generic;

namespace SharedLib
{
    public class Device
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<IPAddrr> IPAddrrs { get; set; }
        public AppUser AppUser { get; set; }
        public string AppUserId { get; set; }
        
    }
}
