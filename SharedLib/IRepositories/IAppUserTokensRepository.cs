using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLib.IRepositories
{
    public interface IAppUserTokensRepository
    {
        AppUserToken Create(AppUserToken appUserToken);
        AppUserToken Get(string id);
        AppUserToken Update(AppUserToken appUserToken);
        void Delete(string id);

    }
}
