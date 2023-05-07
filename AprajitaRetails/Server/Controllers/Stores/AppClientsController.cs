using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AprajitaRetails.Server.Data;
using AprajitaRetails.Shared.Models.Stores;

namespace AprajitaRetails.Server.Controllers.Stores
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppClientsController : ControllerBase
    {
        private readonly ARDBContext _context;

        public AppClientsController(ARDBContext context)
        {
            _context = context;
        }

        // GET: api/AppClinets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppClient>>> GetAppClients()
        {
            if (_context.AppClients == null)
            {
                return NotFound();
            }
            return await _context.AppClients.ToListAsync();
        }
        [HttpGet("AddDefault")]
        public async Task<ActionResult<IEnumerable<AppClient>>> GetAddDefaultAppClient()
        {
            if (_context.AppClients != null)
            {
                return NotFound();
            }
            AppClient appClient = new AppClient
            {
                AppClientId = Guid.NewGuid(),
                City = "Dumka",
                ClientAddress = "Bhagalpur Road",
                ClientName = "Aprajita Retails",
                ExpireDate = null,
                MobileNumber = "9831213339",
                StartDate = new DateTime(2015, 11, 1).Date,

            };
            await _context.AppClients.AddAsync(appClient);
            await _context.SaveChangesAsync();

            return await _context.AppClients.ToListAsync();
        }

        // GET: api/AppClinets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AppClient>> GetAppClient(Guid id)
        {
            if (_context.AppClients == null)
            {
                return NotFound();
            }
            var appClient = await _context.AppClients.FindAsync(id);

            if (appClient == null)
            {
                return NotFound();
            }

            return appClient;
        }

        // PUT: api/AppClinets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppClient(Guid id, AppClient appClient)
        {
            if (id != appClient.AppClientId)
            {
                return BadRequest();
            }

            _context.Entry(appClient).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppClientExists(id))
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

        // POST: api/AppClinets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AppClient>> PostAppClient(AppClient appClient)
        {
            if (_context.AppClients == null)
            {
                return Problem("Entity set 'ARDBContext.AppClients'  is null.");
            }
            _context.AppClients.Add(appClient);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAppClient", new { id = appClient.AppClientId }, appClient);
        }

        // DELETE: api/AppClinets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppClient(Guid id)
        {
            if (_context.AppClients == null)
            {
                return NotFound();
            }
            var appClient = await _context.AppClients.FindAsync(id);
            if (appClient == null)
            {
                return NotFound();
            }

            _context.AppClients.Remove(appClient);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AppClientExists(Guid id)
        {
            return (_context.AppClients?.Any(e => e.AppClientId == id)).GetValueOrDefault();
        }
    }
}
