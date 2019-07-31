using SharedLib;
using SharedLib.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMinotaur.Data;

namespace WebMinotaur.Repositories
{
    public class InfoIpRepository : IInfoIpRepository
    {
        private readonly ApplicationDbContext db;
        public InfoIpRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public InfoIP Create(InfoIP infoIP)
        {
            db.InfoIP.Add(infoIP);
            db.SaveChanges();
            return infoIP;
        }

        public async Task<InfoIP> CreateAsync(InfoIP infoIP)
        {
            db.InfoIP.Add(infoIP);
            await db.SaveChangesAsync();
            return infoIP;
        }

        public InfoIP Get(int id)
        {
            return db.InfoIP.Find(id);
        }

        public async Task<InfoIP> GetAsync(int id)
        {
            return await db.InfoIP.FindAsync(id);
        }
    }
}
