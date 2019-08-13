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
        public JwtSecurityToken GenerateToken(string username)
        {
            var authClaims = new[]
                {
                    new Claim (JwtRegisteredClaimNames.Sub, username),
                    new Claim (JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configService.GetJwtSecret()));

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
            return new JwtSecurityTokenHandler().ReadJwtToken(tokenString);
        }
        public string IntoString(JwtSecurityToken token)
        {
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
