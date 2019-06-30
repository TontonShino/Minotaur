using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharedLibrary;
using Web.Data;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDevicesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UserDevicesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/UserDevices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDevice>>> GetUserDevices()
        {
            return await _context.UserDevices.ToListAsync();
        }

        // GET: api/UserDevices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDevice>> GetUserDevice(string id)
        {
            var userDevice = await _context.UserDevices.FindAsync(id);

            if (userDevice == null)
            {
                return NotFound();
            }

            return userDevice;
        }

        // PUT: api/UserDevices/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserDevice(string id, UserDevice userDevice)
        {
            if (id != userDevice.Id)
            {
                return BadRequest();
            }

            _context.Entry(userDevice).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserDeviceExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/UserDevices
        [HttpPost]
        public async Task<ActionResult<UserDevice>> PostUserDevice(UserDevice userDevice)
        {
            _context.UserDevices.Add(userDevice);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserDeviceExists(userDevice.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUserDevice", new { id = userDevice.Id }, userDevice);
        }

        // DELETE: api/UserDevices/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserDevice>> DeleteUserDevice(string id)
        {
            var userDevice = await _context.UserDevices.FindAsync(id);
            if (userDevice == null)
            {
                return NotFound();
            }

            _context.UserDevices.Remove(userDevice);
            await _context.SaveChangesAsync();

            return userDevice;
        }

        private bool UserDeviceExists(string id)
        {
            return _context.UserDevices.Any(e => e.Id == id);
        }
    }
}
