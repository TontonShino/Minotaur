﻿using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Web.Services
{
    public class UserAuthService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public string getUserIdAsync(ClaimsPrincipal claimsPrincipal)
        {
            return _userManager.GetUserId(claimsPrincipal);
        }
    }
}
