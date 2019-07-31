using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SharedLib.IRepositories
{
    public interface IAppUserTokensRepository
    {
        AppUserToken Create(AppUserToken appUserToken);
        Task<AppUserToken> CreateAsync(AppUserToken appUserToken);
        AppUserToken Get(string id);
        Task<AppUserToken> GetAsync(string id);
        AppUserToken Update(AppUserToken appUserToken);
        Task<AppUserToken> UpdateAsync(AppUserToken appUserToken);
        List<AppUserToken> GetAllByUserId(string userId);
        Task<List<AppUserToken>> GetAllByUserIdAsync(string userId);
        void Delete(string id);
        Task DeleteAsync(string id);
        bool Exists(string id);
        void Enable(string id);
        void Disable(string id);

    }
}
