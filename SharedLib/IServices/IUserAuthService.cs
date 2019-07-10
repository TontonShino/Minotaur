using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace SharedLib.IServices
{
    public interface IUserAuthService
    {
        string GetUserId(ClaimsPrincipal claimsPrincipal);
    }
}
