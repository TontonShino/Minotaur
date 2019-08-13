using Microsoft.AspNetCore.Identity;
using SharedLib;
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
        private readonly UserManager<AppUser> _userManager;
        public UserAuthService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public string GetUserId(ClaimsPrincipal claimsPrincipal)
        {
            return _userManager.GetUserId(claimsPrincipal);
        }
    }
}
