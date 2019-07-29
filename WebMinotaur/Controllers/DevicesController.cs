using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SharedLib;
using SharedLib.IRepositories;
using WebMinotaur.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.Cookies;
using SharedLib.Models;

namespace WebMinotaur.Controllers
{
    //[Authorize(AuthenticationSchemes = "Bearer,Identity.Application")]
    
    [Route("api/[controller]")]
    [ApiController]
    public class DevicesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IDevicesRepository _dr;
        private readonly IAppUserTokensRepository appUserTokensRepository;
        public DevicesController(ApplicationDbContext context, IDevicesRepository dr, IAppUserTokensRepository appUserTokensRepository)
        {
            _context = context;
            _dr = dr;
            this.appUserTokensRepository = appUserTokensRepository;
           
        }
        #region Old code
        ////[HttpGet]
        ////[Route("userdevices/{id}")]
        ////public async Task<ActionResult<List<Device>>> GetUserDevices(string id)
        ////{
        ////    var at = Request.Headers["Authorization"];
        ////    return await _dr.GetDevicesAsyncByUserId(id);
        ////}

        //// GET: api/Devices
        //[HttpGet]
        //[Route("userdevices/{id}")]
        //public async Task<ActionResult<List<Device>>> GetDevices(string id)
        //{
        //    Console.WriteLine("ID entered {id}");
        //    return await _dr.GetDevicesAsyncByUserId(id);
        //}

        //// GET: api/Devices/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Device>> GetDevice(string id)
        //{
        //    var device = await _context.Devices.FindAsync(id);

        //    if (device == null)
        //    {
        //        return NotFound();
        //    }

        //    return device;
        //}

        //// PUT: api/Devices/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutDevice(string id, Device device)
        //{
        //    if (id != device.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(device).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!DeviceExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Devices
        //[HttpPost]
        //public async Task<ActionResult<Device>> PostDevice(Device device)
        //{
        //    _context.Devices.Add(device);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetDevice", new { id = device.Id }, device);
        //}

        //// DELETE: api/Devices/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Device>> DeleteDevice(int id)
        //{
        //    var device = await _context.Devices.FindAsync(id);
        //    if (device == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Devices.Remove(device);
        //    await _context.SaveChangesAsync();

        //    return device;
        //}

        //private bool DeviceExists(string id)
        //{
        //    return _context.Devices.Any(e => e.Id == id);
        //}
        #endregion oldCode
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        [Route("NewDevice")]
        public Device NewDevice([FromBody]DeviceModel deviceModel)
        {
            //get Token
            var accessToken = Request.Headers["Authorization"];
            Console.WriteLine(accessToken);
            return new Device();
        }
    }
}
