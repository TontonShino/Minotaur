using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace SharedLib.IServices
{
    public interface ITokenService
    {
        JwtSecurityToken GenerateTokenDevice(string username);
        JwtSecurityToken DecodeToken(string tokenString);
    }
}
