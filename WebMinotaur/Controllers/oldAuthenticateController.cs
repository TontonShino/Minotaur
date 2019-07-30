using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SharedLib;
using SharedLib.IRepositories;
using SharedLib.IServices;
using SharedLib.Models;


namespace WebMinotaur.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class oldAuthenticateController : ControllerBase
    {
        private readonly UserManager<AppUser> userManager;
        private readonly ITokenService tokenService;
        private readonly IAppUserTokensRepository appUserTokensRepository;


        public oldAuthenticateController
            (
                UserManager<AppUser> userManager,
                ITokenService tokenService,
                IAppUserTokensRepository appUserTokensRepository
            )
        {
            this.userManager = userManager;
            this.tokenService = tokenService;
            this.appUserTokensRepository = appUserTokensRepository;

        }

        [HttpPost]
        [Route("login/")]
        public async Task<IActionResult> Login([FromBody] LoginModel login)
        {
            var user = await userManager.FindByNameAsync(login.Username);

            if (user != null && await userManager.CheckPasswordAsync(user, login.Password))
            {
                var token = tokenService.GenerateToken(user.UserName);
                var appUserToken = new AppUserToken
                {
                    Id = new JwtSecurityTokenHandler().WriteToken(token),
                    ExpirationDate = token.ValidTo,
                    CreationDate = DateTime.UtcNow,
                    Enabled = true,
                    AppUserId = user.Id
                };

                appUserTokensRepository.Create(appUserToken);


                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });


            }
            return Unauthorized();
        }


    }
}