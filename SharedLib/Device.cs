using System;
using System.Collections.Generic;

namespace SharedLib
{
    public class Device
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<InfoIP> InfoIP { get; set; }
        public List<DeviceToken> TokenDevices { get; set; }
        public AppUser AppUser { get; set; }
        public string AppUserId { get; set; }
        
    }
}
