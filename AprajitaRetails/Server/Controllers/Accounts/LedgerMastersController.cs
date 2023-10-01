using AprajitaRetails.Server.Data;
using AprajitaRetails.Shared.Models.Vouchers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AprajitaRetails.Server.Controllers.Accounts
{
    [Route("api/[controller]")]
    [ApiController]
    public class LedgerMastersController : ControllerBase
    {
        private readonly ARDBContext _context;

        public LedgerMastersController(ARDBContext context)
        {
            _context = context;
        }

        // GET: api/LedgerMasters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LedgerMaster>>> GetLedgerMasters()
        {
            if (_context.LedgerMasters == null)
            {
                return NotFound();
            }
            return await _context.LedgerMasters.ToListAsync();
        }
        [HttpGet("ByStore")]
        public async Task<ActionResult<IEnumerable<LedgerMaster>>> GetLedgerMastersByStore(string storeid)
        {
            if (_context.LedgerMasters == null)
            {
                return NotFound();
            }
            return await _context.LedgerMasters.OrderByDescending(c=>c.OpeningDate)
                .ToListAsync();
        }

        // GET: api/LedgerMasters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LedgerMaster>> GetLedgerMaster(string id)
        {
            if (_context.LedgerMasters == null)
            {
                return NotFound();
            }
            var ledgerMaster = await _context.LedgerMasters.FindAsync(id);

            if (ledgerMaster == null)
            {
                return NotFound();
            }

            return ledgerMaster;
        }

        // PUT: api/LedgerMasters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLedgerMaster(string id, LedgerMaster ledgerMaster)
        {
            if (id != ledgerMaster.PartyId)
            {
                return BadRequest();
            }

            _context.Entry(ledgerMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LedgerMasterExists(id))
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

        // POST: api/LedgerMasters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LedgerMaster>> PostLedgerMaster(LedgerMaster ledgerMaster)
        {
            if (_context.LedgerMasters == null)
            {
                return Problem("Entity set 'ARDBContext.LedgerMasters'  is null.");
            }
            _context.LedgerMasters.Add(ledgerMaster);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (LedgerMasterExists(ledgerMaster.PartyId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetLedgerMaster", new { id = ledgerMaster.PartyId }, ledgerMaster);
        }

        // DELETE: api/LedgerMasters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLedgerMaster(string id)
        {
            if (_context.LedgerMasters == null)
            {
                return NotFound();
            }
            var ledgerMaster = await _context.LedgerMasters.FindAsync(id);
            if (ledgerMaster == null)
            {
                return NotFound();
            }

            _context.LedgerMasters.Remove(ledgerMaster);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LedgerMasterExists(string id)
        {
            return (_context.LedgerMasters?.Any(e => e.PartyId == id)).GetValueOrDefault();
        }
    }
}
