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
            throw new NotImplementedException();
        }

        public IEnumerable<DeviceToken> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<DeviceToken>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<DeviceToken> GetAsync(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DeviceToken> GetValidsToken(string deviceid)
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
