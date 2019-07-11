using SharedLib;
using SharedLib.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMinotaur.Data;

namespace WebMinotaur.Repositories
{
    public class DevicesRepository : IDevicesRepository
    {
        private readonly ApplicationDbContext db;
        public DevicesRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public Device AddDevice(Device device)
        {
            db.Devices.Add(device);
            db.SaveChanges();
            return device;
        }

        public async Task<Device> AddDeviceAsync(Device device)
        {
            await db.Devices.AddAsync(device);
            await db.SaveChangesAsync();
            return device;
        }

        public void DeleteDevice(string id)
        {
            var device = db.Devices.Find(id);

            if(device != null)
            {
                db.Devices.Remove(device);
                db.SaveChanges();
            }

        }

        public async Task DeleteDeviceAsync(string id)
        {
            var device = await db.Devices.FindAsync(id);

            if (device != null)
            {
                db.Devices.Remove(device);
                await db.SaveChangesAsync();
            }
        }

        public Device GetDevice(string id)
        {
            return db.Devices.Find(id);
        }

        public async Task<Device> GetDeviceAsync(string id)
        {
            return await db.Devices.FindAsync(id);
        }

        public List<Device> GetDevicesByUserId(string userid)
        {
            return db.Devices.Where(u => u.AppUserId == userid).ToList();
        }

        public async Task<List<Device>> GetDevicesAsyncByUserId(string userid)
        {
            return await db.Devices.Where(u => u.AppUserId == userid).ToAsyncEnumerable().ToList();
        }

        public Device UpdateDevice(Device device)
        {
            db.Devices.Update(device);
            db.SaveChanges();
            return device;
        }

        public async Task<Device> UpdateDeviceAsync(Device device)
        {
            db.Devices.Update(device);
            await db.SaveChangesAsync();
            return device;
        }
    }
}
