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



        public List<DeviceToken> GetValidsToken(string deviceid)
        {
            throw new NotImplementedException();
        }

        public bool IsEnabled(string token)
        {
            throw new NotImplementedException();
        }

        public void Remove(string id)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(string id)
        {
            throw new NotImplementedException();
        }

        public void Revoke(string id)
        {
            throw new NotImplementedException();
        }

        public void RevokeAsync(string id)
        {
            throw new NotImplementedException();
        }

        public DeviceToken Update(DeviceToken tokendevice)
        {
            throw new NotImplementedException();
        }

        public Task<DeviceToken> UpdateAsync(DeviceToken tokendevice)
        {
            throw new NotImplementedException();
        }
    }
}
