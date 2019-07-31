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
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DevicesController : ControllerBase
    {
        private readonly IDevicesRepository devicesRepository;
        private readonly IAppUserTokensRepository appUserTokensRepository;
        private string accessTokenHeader;
        public DevicesController
            (IDevicesRepository devicesRepository,
            IAppUserTokensRepository appUserTokensRepository
            )
        {
            this.devicesRepository = devicesRepository;
            this.appUserTokensRepository = appUserTokensRepository;
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        public ActionResult<Device> PostDevice([FromBody]DeviceModel deviceModel)
        {
            ExtractToken();

            if(accessTokenHeader != null)
            {
                var token = appUserTokensRepository.Get(accessTokenHeader);
                if(token != null && token.Enabled == true)
                {
                    var device = new Device
                    {
                        AppUserId = token.AppUserId,
                        Name = deviceModel.Name,
                        Description = deviceModel.Description
                    };

                    devicesRepository.AddDevice(device);
                    return device;
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