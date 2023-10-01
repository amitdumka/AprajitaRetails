using AprajitaRetails.Server.Data;
using AprajitaRetails.Shared.Models.Vouchers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AprajitaRetails.Server.Controllers.Accounts
{
    [Route("api/[controller]")]
    [ApiController]
    public class LedgerGroupsController : ControllerBase
    {
        private readonly ARDBContext _context;

        public LedgerGroupsController(ARDBContext context)
        {
            _context = context;
        }

        // GET: api/LedgerGroups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LedgerGroup>>> GetLedgerGroups()
        {
            if (_context.LedgerGroups == null)
            {
                return NotFound();
            }
            return await _context.LedgerGroups.ToListAsync();
        }

        // GET: api/LedgerGroups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LedgerGroup>> GetLedgerGroup(string id)
        {
            if (_context.LedgerGroups == null)
            {
                return NotFound();
            }
            var ledgerGroup = await _context.LedgerGroups.FindAsync(id);

            if (ledgerGroup == null)
            {
                return NotFound();
            }

            return ledgerGroup;
        }

        // PUT: api/LedgerGroups/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLedgerGroup(string id, LedgerGroup ledgerGroup)
        {
            if (id != ledgerGroup.LedgerGroupId)
            {
                return BadRequest();
            }

            _context.Entry(ledgerGroup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LedgerGroupExists(id))
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

        // POST: api/LedgerGroups
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LedgerGroup>> PostLedgerGroup(LedgerGroup ledgerGroup)
        {
            if (_context.LedgerGroups == null)
            {
                return Problem("Entity set 'ARDBContext.LedgerGroups'  is null.");
            }
            _context.LedgerGroups.Add(ledgerGroup);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (LedgerGroupExists(ledgerGroup.LedgerGroupId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetLedgerGroup", new { id = ledgerGroup.LedgerGroupId }, ledgerGroup);
        }

        // DELETE: api/LedgerGroups/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLedgerGroup(string id)
        {
            if (_context.LedgerGroups == null)
            {
                return NotFound();
            }
            var ledgerGroup = await _context.LedgerGroups.FindAsync(id);
            if (ledgerGroup == null)
            {
                return NotFound();
            }

            _context.LedgerGroups.Remove(ledgerGroup);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LedgerGroupExists(string id)
        {
            return (_context.LedgerGroups?.Any(e => e.LedgerGroupId == id)).GetValueOrDefault();
        }
    }
}
