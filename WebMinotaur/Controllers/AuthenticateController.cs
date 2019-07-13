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
    public class AuthenticateController : ControllerBase
    {
        private readonly UserManager<AppUser> userManager;
        private readonly ITokenService tokenService;
        private readonly IDeviceTokensRepository deviceTokensRepository;

        public AuthenticateController
            (
                UserManager<AppUser> userManager,
                ITokenService tokenService,
                IDeviceTokensRepository deviceTokensRepository
            )
        {
            this.userManager = userManager;
            this.tokenService = tokenService;
            this.deviceTokensRepository = deviceTokensRepository;

        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel login)
        {
            var user = await userManager.FindByNameAsync(login.Username);

            if (user != null && await userManager.CheckPasswordAsync(user, login.Password))
            {
                var authClaims = new[]
                {
                    new Claim (JwtRegisteredClaimNames.Sub, user.UserName),
                    new Claim (JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("OhalalaMonCoeurDanseLaMacarena"));

                var token = new JwtSecurityToken(
                    issuer: "http://minotaur.fr",
                    audience: "http://minotaur.fr",
                    expires: DateTime.Now.AddMonths(3),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }
            return Unauthorized();
        }



        //[HttpPost]
        //[Route("logout")]
        //public async Task<IActionResult> Logout()
        //{
        //    Authentication.SignOut(CookieAuthenticationDefaults.Authentication);
        //}
    }
}