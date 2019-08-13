using SharedLib;
using SharedLib.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMinotaur.Data;
using Microsoft.EntityFrameworkCore;

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

        public void Delete(int id)
        {
            var infoIp = db.InfoIP.Find(id);
            db.InfoIP.Remove(infoIp);
            db.SaveChanges();
        }

        public async Task DeleteAsync(int id)
        {
            var infoIp = await db.InfoIP.FindAsync(id);
            db.InfoIP.Remove(infoIp);
            await db.SaveChangesAsync();
        }

        public InfoIP Get(int id)
        {
            return db.InfoIP.Find(id);
        }

        public async Task<InfoIP> GetAsync(int id)
        {
            return await db.InfoIP.FindAsync(id);
        }

        public List<InfoIP> GetByDeviceId(string deviceId)
        {
            return db.InfoIP.Where(d => d.DeviceId == deviceId).ToList();
        }

        public async Task<List<InfoIP>> GetByDeviceIdAsync(string deviceId)
        {
            return await db.InfoIP.Where(d => d.DeviceId == deviceId).ToListAsync();
        }

        public List<InfoIP> GetRecents(string deviceId)
        {
            //Todo: test if really 10 last
            return db.InfoIP.Where(d => d.DeviceId == deviceId).OrderByDescending(d => d.Record).Take(10).ToList();
        }

        public async Task<List<InfoIP>> GetRecentsAsync(string deviceId)
        {
            //Todo: test if really 10 last
            return await db.InfoIP.Where(d => d.DeviceId == deviceId).OrderByDescending( d => d.Record).Take(10).ToListAsync();
        }
    }
}
