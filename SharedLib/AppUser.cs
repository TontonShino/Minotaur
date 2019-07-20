using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLib
{
    public class AppUser : IdentityUser
    {

        public virtual ICollection<Device> Devices { get; set; }
        public virtual ICollection<AppUserToken> AppUserTokens { get; set; }

        public AppUser()
        {
            this.Devices = new HashSet<Device>();
            this.AppUserTokens = new HashSet<AppUserToken>();
        }

    }
}
