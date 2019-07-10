using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLib.IServices
{
    public interface IConfigService
    {
        string GetJwtSecret();
        string GetAudience();
        string GetIssuer();
    }
}
