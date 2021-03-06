﻿using Microsoft.EntityFrameworkCore;
using SharedLib;
using SharedLib.IRepositories;
using SharedLib.IServices;
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
            device.CreationDate = DateTime.UtcNow;
            device.LastUpdateDate = DateTime.UtcNow;
            db.Devices.Add(device);
            db.SaveChanges();
            return device;
        }

        public async Task<Device> AddDeviceAsync(Device device)
        {
            device.CreationDate = DateTime.UtcNow;
            device.LastUpdateDate = DateTime.UtcNow;
            await db.Devices.AddAsync(device);
            await db.SaveChangesAsync();
            return device;
        }

        public void DeleteDevice(string id)
        {
            var device = db.Devices.Find(id);

            if (device != null)
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
                var infoIps = db.InfoIP.Where(d => d.DeviceId == id);
                db.InfoIP.RemoveRange(infoIps);
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
            //return db.Devices.Where(u => u.AppUserId == userid).ToList();
            return db.Devices.Where(u => u.AppUserId == userid).ToList();
        }

        public async Task<List<Device>> GetDevicesAsyncByUserId(string userid)
        {
            //return await db.Devices.Where(u => u.AppUserId == userid).Include(t => t.TokenDevices).ToListAsync();
            return await db.Devices.Where(u => u.AppUserId == userid).ToListAsync();

        }

        public Device UpdateDevice(Device device)
        {

            db.Entry(device).State = EntityState.Modified;
            try
            {
                device.LastUpdateDate = DateTime.UtcNow;
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeviceExists(device.Id))
                {
                    //Todo    
                }
                else
                {
                    throw;
                }
            }
            return device;
        }

        public async Task<Device> UpdateDeviceAsync(Device device)
        {
            device.LastUpdateDate = DateTime.UtcNow;
            db.Devices.Update(device);
            await db.SaveChangesAsync();
            return device;
        }

        public bool DeviceExists(string id)
        {
            return db.Devices.Any(e => e.Id == id);
        }

        public async Task<List<Device>> GetDevicesLastIpAsync(string userid)
        {
            var devices = await db.Devices.Where(u => u.AppUserId == userid).Include(t => t.InfoIP).AsNoTracking().ToListAsync();

            var filteredDevices = from d in devices
                                  select new Device
                                  {
                                      Id = d.Id,
                                      Name = d.Name,
                                      Description = d.Description,
                                      AppUserId = d.AppUserId,
                                      InfoIP = (d.InfoIP.Count>0) ? new List<InfoIP>
                                      {
                                         d.InfoIP.OrderByDescending(w => w.Record).FirstOrDefault()
                                      } : null


                                  };
            return filteredDevices.ToList();

        }

        public List<Device> GetDevicesLastIp(string userid)
        {
            var devices =  db.Devices.Where(u => u.AppUserId == userid).Include(t => t.InfoIP);

            var filteredDevices = from d in devices
                                  select new Device
                                  {
                                      Id = d.Id,
                                      Name = d.Name,
                                      Description = d.Description,
                                      AppUserId = d.AppUserId,
                                      InfoIP = (d.InfoIP.Count > 0) ? new List<InfoIP>
                                      {
                                         d.InfoIP.OrderByDescending(w => w.Record).FirstOrDefault()
                                      } : null


                                  };
            return filteredDevices.ToList();
        }

        public async Task<List<InfoIP>> GetDeviceHistoryAsync(string deviceId)
        {
            return await db.InfoIP.Where(d => d.DeviceId == deviceId).Include(d => d.Device).ToListAsync();
        }

        public List<InfoIP> GetDeviceHistory(string deviceId)
        {
            return db.InfoIP.Where(d => d.DeviceId == deviceId).Include(d => d.Device).AsNoTracking().ToList();
        }
    }
}
