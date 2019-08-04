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
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class InfoIpController : ControllerBase
    {
        private readonly IInfoIpRepository infoIpRepository;
        private readonly IAppUserTokensRepository appUserTokensRepository;
        private readonly IDevicesRepository devicesRepository;
        private string accessTokenHeader;
        public InfoIpController
            (IInfoIpRepository infoIpRepository,
            IAppUserTokensRepository appUserTokensRepository,
            IDevicesRepository devicesRepository)
        {
            this.infoIpRepository = infoIpRepository;
            this.appUserTokensRepository = appUserTokensRepository;
            this.devicesRepository = devicesRepository;
        }



        [HttpPost]
        public async Task<ActionResult<InfoIP>> PostInfoIp([FromBody]InfoIpModel infoIpModel)
        {
            ExtractToken();
            if (accessTokenHeader != null)
            {
                var token = appUserTokensRepository.Get(accessTokenHeader);
                if (token != null)
                {
                    var device = await devicesRepository.GetDeviceAsync(infoIpModel.deviceId);
                    if (device.AppUserId == token.AppUserId)
                    {

                        var infoIp = new InfoIP
                        {
                            DeviceId = infoIpModel.deviceId,
                            Ip = infoIpModel.ip,
                            Record = DateTime.UtcNow
                        };
                        await infoIpRepository.CreateAsync(infoIp);
                        infoIp.Device = null; //If not null cause Error
                        return infoIp;
                    }
                }
            }
            return Unauthorized(new { message = "Unauthorized" });
        }

        [HttpGet]
        [Route("recents/{id}")]
        public async Task<ActionResult<List<InfoIP>>> GetInfoIpLastByDeviceIdAsync(string id)
        {
            ExtractToken();

            if (accessTokenHeader != null)
            {
                var token = appUserTokensRepository.Get(accessTokenHeader);
                if (token != null)
                {
                    var device = await devicesRepository.GetDeviceAsync(id);
                    if (device.AppUserId == token.AppUserId)
                    {
                        var infoIps = await infoIpRepository.GetLastAsync(id);
                        return infoIps;
                    }
                    return NotFound(new
                    {
                        message = "Not found"
                    });

                }
            }

            return Unauthorized(new
            {
                message = "request new token"
            });
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<InfoIP>> GetInfoIPAsync(int id)
        {
            ExtractToken();

            if (accessTokenHeader != null)
            {
                var token = appUserTokensRepository.Get(accessTokenHeader);
                if (token != null)
                {
                    var infoIp = await infoIpRepository.GetAsync(id);
                    var device = await devicesRepository.GetDeviceAsync(infoIp.DeviceId);

                    if (device.AppUserId == token.AppUserId)
                    {
                        await infoIpRepository.GetAsync(id);
                        return infoIp;
                    }
                    return NotFound(new { message = "Not Found" });
                }
            }
            return Unauthorized(new { message = "Unauthorized" });
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteInfoIp(int id)
        {
            ExtractToken();
            var token = appUserTokensRepository.Get(accessTokenHeader);
            if (token != null)
            {
                var infoIp = await infoIpRepository.GetAsync(id);
                var device = await devicesRepository.GetDeviceAsync(infoIp.DeviceId);
                if (device.AppUserId == token.AppUserId)
                {
                    await infoIpRepository.DeleteAsync(id);
                    return Ok(new { message = "Deleted" });
                }
                return NotFound(new { message = "Not Found" });

            }
            return Unauthorized();
        }
        private void ExtractToken()
        {
            accessTokenHeader = Request.Headers["Authorization"].ToString().Replace("Bearer", "").Trim();
        }
    }
}