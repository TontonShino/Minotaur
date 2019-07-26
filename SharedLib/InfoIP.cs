﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SharedLib
{
    public class InfoIP
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Ip { get; set; }
        public DateTime Record { get; set; }
        public string DeviceId { get; set; }
        public Device Device { get; set; }

    }
}
