using Microsoft.EntityFrameworkCore;
using SharedLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Data
{

    public class ApplicationDbContext : DbContext
    {
        public virtual DbSet<UserDevice> UserDevices { get; set; }
        public virtual DbSet<Device> Devices { get; set; }
        public virtual DbSet<IPAddrr> IPAddrrs { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public ApplicationDbContext() { }

    }
}
