using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SharedLib.IRepositories
{
    public interface IAppUserTokensRepository
    {
        AppUserToken Create(AppUserToken appUserToken);
        AppUserToken Get(string id);
        AppUserToken Update(AppUserToken appUserToken);
        List<AppUserToken> GetAllByUserId(string userId);
        Task<List<AppUserToken>> GetAllByUserIdAsync(string userId);
        void Delete(string id);
        bool Exists(string id);

    }
}
