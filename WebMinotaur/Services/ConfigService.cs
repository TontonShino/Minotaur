using Microsoft.Extensions.Configuration;
using SharedLib.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMinotaur.Services
{
    public class ConfigService : IConfigService
    {
        private readonly IConfiguration configuration; 
        public ConfigService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string GetJwtSecret()
        {
            return configuration.GetSection("Secrets:jwt").Value;
        }

        public string GetAudience()
        {
            return configuration.GetSection("JwtParams:Audience").Value;
        }

        public string GetIssuer()
        {
            return configuration.GetSection("JwtParams:Issuer").Value;
        }

    }
}
