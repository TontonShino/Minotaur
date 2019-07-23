using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SharedLib.IRepositories
{
    public interface IDeviceTokensRepository
    {
        //Create
        DeviceToken Create(DeviceToken tokendevice);
        Task<DeviceToken> CreateAsync(DeviceToken tokenDevice);
        //Read
        DeviceToken Get(string id);
        Task<DeviceToken> GetAsync(string id);
        //Update
        DeviceToken Update(DeviceToken tokendevice);
        Task<DeviceToken> UpdateAsync(DeviceToken tokendevice);
        //Delete
        void Remove(string id);
        Task RemoveAsync(string id);
        List<DeviceToken> GetAllByUserId(string userId);
        Task<List<DeviceToken>> GetAllByUserIdAsync(string userId);
        //Revoke
        void Revoke(string id);
        void RevokeAsync(string id);
        //GetValidsTokens
        List<DeviceToken> GetValidsToken(string deviceid);
        //IsEnabled
        bool IsEnabled(string token);
    }
}
