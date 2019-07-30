using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SharedLib;
using SharedLib.IRepositories;
using SharedLib.IServices;
using SharedLib.Models;

namespace WebMinotaur.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ITokenService tokenService;
        private readonly IAppUserTokensRepository appUserTokensRepository;
        private readonly UserManager<AppUser> userManager;

        public AuthController(
            ITokenService tokenService,
            IAppUserTokensRepository appUserTokensRepository,
            UserManager<AppUser> userManager
            ){

            this.tokenService = tokenService;
            this.userManager = userManager;
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