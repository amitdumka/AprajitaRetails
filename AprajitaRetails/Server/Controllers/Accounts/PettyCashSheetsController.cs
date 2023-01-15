using AprajitaRetails.Server.Data;
using AprajitaRetails.Shared.Models.Vouchers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AprajitaRetails.Server.Controllers.Accounts
{
    [Route("[controller]")]
    [ApiController]
    public class PettyCashSheetsController : ControllerBase
    {
        private readonly ARDBContext _context;

        public PettyCashSheetsController(ARDBContext context)
        {
            _context = context;
        }

        // GET: api/PettyCashSheets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PettyCashSheet>>> GetPettyCashSheets()
        {
            if (_context.PettyCashSheets == null)
            {
                return NotFound();
            }
            return await _context.PettyCashSheets.ToListAsync();
        }

        // GET: api/PettyCashSheets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PettyCashSheet>> GetPettyCashSheet(string id)
        {
            if (_context.PettyCashSheets == null)
            {
                return NotFound();
            }
            var pettyCashSheet = await _context.PettyCashSheets.FindAsync(id);

            if (pettyCashSheet == null)
            {
                return NotFound();
            }

            return pettyCashSheet;
        }

        // PUT: api/PettyCashSheets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPettyCashSheet(string id, PettyCashSheet pettyCashSheet)
        {
            if (id != pettyCashSheet.Id)
            {
                return BadRequest();
            }

            _context.Entry(pettyCashSheet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PettyCashSheetExists(id))
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

        // POST: api/PettyCashSheets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PettyCashSheet>> PostPettyCashSheet(PettyCashSheet pettyCashSheet)
        {
            if (_context.PettyCashSheets == null)
            {
                return Problem("Entity set 'ARDBContext.PettyCashSheets'  is null.");
            }
            _context.PettyCashSheets.Add(pettyCashSheet);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PettyCashSheetExists(pettyCashSheet.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPettyCashSheet", new { id = pettyCashSheet.Id }, pettyCashSheet);
        }

        // DELETE: api/PettyCashSheets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePettyCashSheet(string id)
        {
            if (_context.PettyCashSheets == null)
            {
                return NotFound();
            }
            var pettyCashSheet = await _context.PettyCashSheets.FindAsync(id);
            if (pettyCashSheet == null)
            {
                return NotFound();
            }

            _context.PettyCashSheets.Remove(pettyCashSheet);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PettyCashSheetExists(string id)
        {
            return (_context.PettyCashSheets?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
