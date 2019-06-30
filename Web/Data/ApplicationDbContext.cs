using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SharedLibrary;


namespace Web.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public virtual DbSet<UserDevice> UserDevices { get; set; }
        public virtual DbSet<Device> Devices { get; set; }
        public virtual DbSet<IPAddrr> IPAddrrs { get; set; }
        public ApplicationDbContext() { }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }
    }
}
