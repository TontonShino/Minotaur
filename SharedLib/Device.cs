﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SharedLib
{
    public class Device
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public List<InfoIP> InfoIP { get; set; }
        public List<DeviceToken> TokenDevices { get; set; }
        public AppUser AppUser { get; set; }
        public string AppUserId { get; set; }
        
    }
}
