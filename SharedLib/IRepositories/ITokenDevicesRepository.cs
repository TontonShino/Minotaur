using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SharedLib.IRepositories
{
    public interface ITokenDevicesRepository
    {
        //Create
        TokenDevice create(TokenDevice tokendevice);
        Task<TokenDevice> CreateAsync(TokenDevice tokenDevice);
        //Read
        TokenDevice Get(string id);
        Task<TokenDevice> GetAsync(string id);
        //Update
        TokenDevice Update(TokenDevice tokendevice);
        Task<TokenDevice> UpdateAsync(TokenDevice tokendevice);
        //Delete
        void Remove(string id);
        Task RemoveAsync(string id);
        //GetAll
        IEnumerable<TokenDevice> GetAll();
        Task<IEnumerable<TokenDevice>> GetAllAsync();
        //Revoke
        void Revoke(string id);
        void RevokeAsync(string id);
        //GetValidsTokens
        IEnumerable<TokenDevice> GetValidsToken(string deviceid);
        //IsEnabled
        bool IsEnabled(string token);
    }
}
