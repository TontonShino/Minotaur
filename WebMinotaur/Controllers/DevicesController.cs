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


        [HttpPost]
        public ActionResult<Device> PostDevice([FromBody]DeviceModel deviceModel)
        {
            ExtractToken();

            if (accessTokenHeader != null)
            {
                var token = appUserTokensRepository.Get(accessTokenHeader);
                if (token != null)
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

        [HttpGet]
        public async Task<ActionResult<List<Device>>> GetDevicesAsync()
        {
            ExtractToken();
            if (accessTokenHeader != null)
            {
                var token = appUserTokensRepository.Get(accessTokenHeader);
                if (token != null)
                {
                    var devices = await devicesRepository.GetDevicesAsyncByUserId(token.AppUserId);
                    return devices;
                }
            }
            return Unauthorized();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Device>> GetDeviceAsync(string id)
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
                        return device;
                    }

                }
            }
            return Unauthorized();
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<Device>> PutDeviceAsync(string id, [FromBody]DeviceModel deviceModel)
        {
            ExtractToken();

            if (accessTokenHeader != null)
            {
                var token = appUserTokensRepository.Get(accessTokenHeader);
                if (token != null)
                {
                    var device = await devicesRepository.GetDeviceAsync(id);
                    if (token.AppUserId == device.AppUserId)
                    {
                        device.Name = deviceModel?.Name;
                        device.Description = device?.Description;
                        await devicesRepository.UpdateDeviceAsync(device);
                        return device;
                    }
                    return NotFound();
                }
            }
            return Unauthorized();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteDeviceAsync(string id)
        {
            var token = appUserTokensRepository.Get(accessTokenHeader);
            if (token != null)
            {
                var device = await devicesRepository.GetDeviceAsync(id);
                if (token.AppUserId == device.AppUserId)
                {
                    await devicesRepository.DeleteDeviceAsync(id);
                    return Ok();
                }
                return NotFound();
            }
            return Unauthorized();
        }
        private void ExtractToken()
        {
            accessTokenHeader = Request.Headers["Authorization"].ToString().Replace("Bearer", "").Trim();
        }
    }
}