using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLibrary
{
    public class AppUser : IdentityUser
    {
        public List<Device> Devices { get; set; }

    }
}
