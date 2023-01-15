using AprajitaRetails.Server.Data;
using AprajitaRetails.Shared.Models.Stores;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AprajitaRetails.Server.Controllers.Accounts
{
    [Route("[controller]")]
    [ApiController]
    public class DueRecoveriesController : ControllerBase
    {
        private readonly ARDBContext _context;

        public DueRecoveriesController(ARDBContext context)
        {
            _context = context;
        }

        // GET: api/DueRecoveries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DueRecovery>>> GetDuesRecovery()
        {
            if (_context.DuesRecovery == null)
            {
                return NotFound();
            }
            return await _context.DuesRecovery.ToListAsync();
        }

        // GET: api/DueRecoveries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DueRecovery>> GetDueRecovery(string id)
        {
            if (_context.DuesRecovery == null)
            {
                return NotFound();
            }
            var dueRecovery = await _context.DuesRecovery.FindAsync(id);

            if (dueRecovery == null)
            {
                return NotFound();
            }

            return dueRecovery;
        }

        // PUT: api/DueRecoveries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDueRecovery(string id, DueRecovery dueRecovery)
        {
            if (id != dueRecovery.Id)
            {
                return BadRequest();
            }

            _context.Entry(dueRecovery).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DueRecoveryExists(id))
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

        // POST: api/DueRecoveries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DueRecovery>> PostDueRecovery(DueRecovery dueRecovery)
        {
            if (_context.DuesRecovery == null)
            {
                return Problem("Entity set 'ARDBContext.DuesRecovery'  is null.");
            }
            _context.DuesRecovery.Add(dueRecovery);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DueRecoveryExists(dueRecovery.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDueRecovery", new { id = dueRecovery.Id }, dueRecovery);
        }

        // DELETE: api/DueRecoveries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDueRecovery(string id)
        {
            if (_context.DuesRecovery == null)
            {
                return NotFound();
            }
            var dueRecovery = await _context.DuesRecovery.FindAsync(id);
            if (dueRecovery == null)
            {
                return NotFound();
            }

            _context.DuesRecovery.Remove(dueRecovery);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DueRecoveryExists(string id)
        {
            return (_context.DuesRecovery?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}