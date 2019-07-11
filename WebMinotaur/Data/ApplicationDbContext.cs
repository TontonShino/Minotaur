using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SharedLib;

namespace WebMinotaur.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public virtual DbSet<AppUser> AppUsers { get; set; }
        public virtual DbSet<Device> Devices { get; set; }
        public virtual DbSet<InfoIP> InfoIP { get; set; }
        public virtual DbSet<DeviceToken> DeviceTokens { get; set; }


    }
}
