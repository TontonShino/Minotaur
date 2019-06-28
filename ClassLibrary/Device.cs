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
        public User User { get; set; }
        public int UserId { get; set; }
        
    }
}
