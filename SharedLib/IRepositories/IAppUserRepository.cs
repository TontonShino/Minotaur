using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLib.IRepositories
{
    public interface IAppUserRepository
    {
        AppUser Get(string id);
        AppUser GetByUsername(string username);
    }
}
