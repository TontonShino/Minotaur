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
            //var stream = "[encoded jwt]";
            //var handler = new JwtSecurityTokenHandler();
            //var jsonToken = handler.ReadToken(stream);
            //var tokenS = handler.ReadToken(tokenJwtReponse.access_token) as JwtSecurityToken;
            //I can get Claims using:

            //var jti = tokenS.Claims.First(claim => claim.Type == "jti").Value;
            throw new NotImplementedException();
        }

    }
}
