using AprajitaRetails.Server.Data;
using AprajitaRetails.Shared.Models.Vouchers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AprajitaRetails.Server.Controllers.Vouchers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionModesController : ControllerBase
    {
        private readonly ARDBContext _context;

        public TransactionModesController(ARDBContext context)
        {
            _context = context;
        }

        // GET: api/TransactionModes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TransactionMode>>> GetTransactionModes()
        {
            if (_context.TransactionModes == null)
            {
                return NotFound();
            }
            return await _context.TransactionModes.ToListAsync();
        }

        // GET: api/TransactionModes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TransactionMode>> GetTransactionMode(string id)
        {
            if (_context.TransactionModes == null)
            {
                return NotFound();
            }
            var transactionMode = await _context.TransactionModes.FindAsync(id);

            if (transactionMode == null)
            {
                return NotFound();
            }

            return transactionMode;
        }

        // PUT: api/TransactionModes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTransactionMode(string id, TransactionMode transactionMode)
        {
            if (id != transactionMode.TransactionId)
            {
                return BadRequest();
            }

            //TODO: Transcation ID Generation
            _context.Entry(transactionMode).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransactionModeExists(id))
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

        // POST: api/TransactionModes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TransactionMode>> PostTransactionMode(TransactionMode transactionMode)
        {
            if (_context.TransactionModes == null)
            {
                return Problem("Entity set 'ARDBContext.TransactionModes'  is null.");
            }
            _context.TransactionModes.Add(transactionMode);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TransactionModeExists(transactionMode.TransactionId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTransactionMode", new { id = transactionMode.TransactionId }, transactionMode);
        }

        // DELETE: api/TransactionModes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransactionMode(string id)
        {
            if (_context.TransactionModes == null)
            {
                return NotFound();
            }
            var transactionMode = await _context.TransactionModes.FindAsync(id);
            if (transactionMode == null)
            {
                return NotFound();
            }

            _context.TransactionModes.Remove(transactionMode);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TransactionModeExists(string id)
        {
            return (_context.TransactionModes?.Any(e => e.TransactionId == id)).GetValueOrDefault();
        }
    }
}
