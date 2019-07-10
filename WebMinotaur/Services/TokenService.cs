using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SharedLib.IServices;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace WebMinotaur.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfigService configService;
        public TokenService(IConfigService configService)
        {
            this.configService = configService;
        }
        public JwtSecurityToken GenerateTokenDevice(string username)
        {
            var authClaims = new[]
                {
                    new Claim (JwtRegisteredClaimNames.Sub, username),
                    new Claim (JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("OhalalaMonCoeurDanseLaMacarena"));

            var token = new JwtSecurityToken(
                issuer: configService.GetIssuer(),
                audience: configService.GetAudience(),
                expires: DateTime.Now.AddMonths(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );
            return token;
        }

        public JwtSecurityToken DecodeToken(string tokenString)
        {
            //source: https://stackoverflow.com/questions/38340078/how-to-decode-jwt-token
            //Todo: To test !!!
            return new JwtSecurityTokenHandler().ReadJwtToken(tokenString);
        }

    }
}
