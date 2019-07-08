using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLib
{
    public class AppUser : IdentityUser
    {
        public List<Device> Devices { get; set; }

    }
}
