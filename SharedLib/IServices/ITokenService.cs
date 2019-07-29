using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace SharedLib.IServices
{
    public interface ITokenService
    {
        JwtSecurityToken GenerateToken(string username);
        JwtSecurityToken DecodeToken(string tokenString);
        bool IsValid(string tokenString);
        string IntoString(JwtSecurityToken token);

    }
}
