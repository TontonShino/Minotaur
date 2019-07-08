using SharedLib.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebMinotaur.Services
{
    public class UserAuthService : IUserAuthService
    {
        public string getUserId(ClaimsPrincipal claimsPrincipal)
        {
            throw new NotImplementedException();
        }
    }
}
