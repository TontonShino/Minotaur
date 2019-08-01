using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedLib;
using SharedLib.IRepositories;
using SharedLib.Models;

namespace WebMinotaur.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InfoIpController : ControllerBase
    {
        private readonly IInfoIpRepository infoIpRepository;
        private readonly IAppUserTokensRepository appUserTokensRepository;
        private string accessTokenHeader;
        public InfoIpController
            (IInfoIpRepository infoIpRepository,
            IAppUserTokensRepository appUserTokensRepository)
        {
            this.infoIpRepository = infoIpRepository;
            this.appUserTokensRepository = appUserTokensRepository;
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        public ActionResult<InfoIP> PostInfoIp([FromBody]InfoIpModel infoIpModel)
        {
            ExtractToken();
            if(accessTokenHeader != null)
            {
                var token = appUserTokensRepository.Get(accessTokenHeader);
                if(token != null) { 
                    var infoIp = new InfoIP
                    {
                        DeviceId = infoIpModel.deviceId,
                        Ip = infoIpModel.ip,
                        Record = DateTime.UtcNow
                    };
                    infoIpRepository.Create(infoIp);
                    return infoIp;
                }
            }
            return Unauthorized();
        }
        private void ExtractToken()
        {
            accessTokenHeader = Request.Headers["Authorization"].ToString().Replace("Bearer", "").Trim();
        }
    }
}