using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SharedLibrary;

namespace Web.Data
{
    public class AppUser : IdentityUser
    {

        [PersonalData]
        public string Nom { get; set; }
        [PersonalData]
        public string Prenom { get; set; }
        [PersonalData]
        public DateTime DOB { get; set; }
        public List<Device> Devices { get; set; }


    }
}