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
    public class IPAddrrsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public IPAddrrsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/IPAddrrs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IPAddrr>>> GetIPAddrrs()
        {
            return await _context.IPAddrrs.ToListAsync();
        }

        // GET: api/IPAddrrs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IPAddrr>> GetIPAddrr(int id)
        {
            var iPAddrr = await _context.IPAddrrs.FindAsync(id);

            if (iPAddrr == null)
            {
                return NotFound();
            }

            return iPAddrr;
        }

        // PUT: api/IPAddrrs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIPAddrr(int id, IPAddrr iPAddrr)
        {
            if (id != iPAddrr.Id)
            {
                return BadRequest();
            }

            _context.Entry(iPAddrr).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IPAddrrExists(id))
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

        // POST: api/IPAddrrs
        [HttpPost]
        public async Task<ActionResult<IPAddrr>> PostIPAddrr(IPAddrr iPAddrr)
        {
            _context.IPAddrrs.Add(iPAddrr);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIPAddrr", new { id = iPAddrr.Id }, iPAddrr);
        }

        // DELETE: api/IPAddrrs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IPAddrr>> DeleteIPAddrr(int id)
        {
            var iPAddrr = await _context.IPAddrrs.FindAsync(id);
            if (iPAddrr == null)
            {
                return NotFound();
            }

            _context.IPAddrrs.Remove(iPAddrr);
            await _context.SaveChangesAsync();

            return iPAddrr;
        }

        private bool IPAddrrExists(int id)
        {
            return _context.IPAddrrs.Any(e => e.Id == id);
        }
    }
}
