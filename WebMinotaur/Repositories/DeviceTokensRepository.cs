using Microsoft.EntityFrameworkCore;
using SharedLib;
using SharedLib.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMinotaur.Data;

namespace WebMinotaur.Repositories
{
    public class DeviceTokensRepository : IDeviceTokensRepository
    {
        private readonly ApplicationDbContext db;
        public DeviceTokensRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public DeviceToken Create(DeviceToken tokendevice)
        {
            db.Add(tokendevice);
            db.SaveChanges();
            return tokendevice;
        }

        public async Task<DeviceToken> CreateAsync(DeviceToken tokenDevice)
        {
            db.DeviceTokens.Add(tokenDevice);
            await db.SaveChangesAsync();
            return tokenDevice;
        }

        public DeviceToken Get(string id)
        {
            return db.DeviceTokens.Find(id);
        }
        public async Task<DeviceToken> GetAsync(string id)
        {
            return await db.DeviceTokens.FindAsync(id);
        }

        public List<DeviceToken> GetAllByUserId(string userId)
        {
            var devices = db.Devices.Where(u => u.AppUserId == userId).Include(t => t.TokenDevices);
            List<DeviceToken> tkds = new List<DeviceToken>();
            foreach (var d in devices)
            {
                foreach (var tk in d.TokenDevices)
                {
                    tkds.Add(tk);
                }
            }
            return tkds;
        }

        public async Task<List<DeviceToken>> GetAllByUserIdAsync(string userId)
        {
            var devices = await db.Devices.Where(u => u.AppUserId == userId).Include(t => t.TokenDevices).ToListAsync();
            List<DeviceToken> tkds = new List<DeviceToken>();
            foreach (var d in devices)
            {
                foreach (var tk in d.TokenDevices)
                {
                    tkds.Add(tk);
                }
            }
            return tkds;
        }




        public bool IsEnabled(string token)
        {
            var tkd = db.DeviceTokens.Find(token);

            return tkd != null ? tkd.Enabled : false;
        }

        public void Remove(string id)
        {
            var deviceToken = db.DeviceTokens.Find(id);
            db.DeviceTokens.Remove(deviceToken);
            db.SaveChanges();

        }

        public async Task RemoveAsync(string id)
        {
            var deviceToken = db.DeviceTokens.Find(id);
            db.DeviceTokens.Remove(deviceToken);
            await db.SaveChangesAsync();
        }

        public DeviceToken Update(DeviceToken tokendevice)
        {
            db.DeviceTokens.Update(tokendevice);
            db.SaveChanges();
            return tokendevice;
        }

        public async Task<DeviceToken> UpdateAsync(DeviceToken tokendevice)
        {
            db.DeviceTokens.Update(tokendevice);
            await db.SaveChangesAsync();
            return tokendevice;
        }

        public void Disable(string id)
        {
            var deviceToken = db.DeviceTokens.Find(id);
            deviceToken.Enabled = false;
            db.SaveChanges();
        }

        public async Task DisableAsync(string id)
        {
            var deviceToken = await db.DeviceTokens.FindAsync(id);
            deviceToken.Enabled = false;
            await db.SaveChangesAsync();
        }

        public void Enable(string id)
        {
            var deviceToken = db.DeviceTokens.Find(id);
            deviceToken.Enabled = true;
            db.SaveChanges();
        }

        public async Task EnableAsync(string id)
        {
            var deviceToken = await db.DeviceTokens.FindAsync(id);
            deviceToken.Enabled = true;
            await db.SaveChangesAsync();
        }
    }
}
