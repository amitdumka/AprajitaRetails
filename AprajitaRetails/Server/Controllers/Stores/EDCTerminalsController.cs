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
    [Route("[controller]")]
    [ApiController]
    public class EDCTerminalsController : ControllerBase
    {
        private readonly ARDBContext _context;

        public EDCTerminalsController(ARDBContext context)
        {
            _context = context;
        }

        // GET: api/EDCTerminals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EDCTerminal>>> GetEDCTerminals()
        {
            if (_context.EDCTerminals == null)
            {
                return NotFound();
            }
            return await _context.EDCTerminals.ToListAsync();
        }

        // GET: api/EDCTerminals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EDCTerminal>> GetEDCTerminal(string id)
        {
            if (_context.EDCTerminals == null)
            {
                return NotFound();
            }
            var eDCTerminal = await _context.EDCTerminals.FindAsync(id);

            if (eDCTerminal == null)
            {
                return NotFound();
            }

            return eDCTerminal;
        }

        // PUT: api/EDCTerminals/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEDCTerminal(string id, EDCTerminal eDCTerminal)
        {
            if (id != eDCTerminal.EDCTerminalId)
            {
                return BadRequest();
            }

            _context.Entry(eDCTerminal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EDCTerminalExists(id))
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

        // POST: api/EDCTerminals
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EDCTerminal>> PostEDCTerminal(EDCTerminal eDCTerminal)
        {
            if (_context.EDCTerminals == null)
            {
                return Problem("Entity set 'ARDBContext.EDCTerminals'  is null.");
            }
            _context.EDCTerminals.Add(eDCTerminal);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EDCTerminalExists(eDCTerminal.EDCTerminalId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEDCTerminal", new { id = eDCTerminal.EDCTerminalId }, eDCTerminal);
        }

        // DELETE: api/EDCTerminals/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEDCTerminal(string id)
        {
            if (_context.EDCTerminals == null)
            {
                return NotFound();
            }
            var eDCTerminal = await _context.EDCTerminals.FindAsync(id);
            if (eDCTerminal == null)
            {
                return NotFound();
            }

            _context.EDCTerminals.Remove(eDCTerminal);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EDCTerminalExists(string id)
        {
            return (_context.EDCTerminals?.Any(e => e.EDCTerminalId == id)).GetValueOrDefault();
        }
    }
}