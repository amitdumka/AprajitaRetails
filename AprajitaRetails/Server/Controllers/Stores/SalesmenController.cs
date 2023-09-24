using AprajitaRetails.Server.Data;
using AprajitaRetails.Shared.Models.Stores;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AprajitaRetails.Server.Controllers.Stores
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesmenController : ControllerBase
    {
        private readonly ARDBContext _context;

        public SalesmenController(ARDBContext context)
        {
            _context = context;
        }

        // GET: api/Salesmen
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Salesman>>> GetSalesman()
        {
            if (_context.Salesmen == null)
            {
                return NotFound();
            }
            return await _context.Salesmen.ToListAsync();
        }
        [HttpGet("ByStore")]
        public async Task<ActionResult<IEnumerable<Salesman>>> GetSalesmanByStore(string storeid)
        {
            if (_context.Salesmen == null)
            {
                return NotFound();
            }
            //return await _context.Salesmen.Where(c=>c.StoreId==storeid && !c.MarkedDeleted ).ToListAsync();
            return await _context.Salesmen.Where(c => c.StoreId == storeid ).ToListAsync();

        }

        // GET: api/Salesmen/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Salesman>> GetSalesman(string id)
        {
            if (_context.Salesmen == null)
            {
                return NotFound();
            }
            var salesman = await _context.Salesmen.FindAsync(id);

            if (salesman == null)
            {
                return NotFound();
            }

            return salesman;
        }

        // PUT: api/Salesmen/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSalesman(string id, Salesman salesman)
        {
            if (id != salesman.SalesmanId)
            {
                return BadRequest();
            }

            _context.Entry(salesman).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalesmanExists(id))
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

        // POST: api/Salesmen
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Salesman>> PostSalesman(Salesman salesman)
        {
            if (_context.Salesmen == null)
            {
                return Problem("Entity set 'ARDBContext.Salesman'  is null.");
            }

            //TODO: Salemen id generation
            _context.Salesmen.Add(salesman);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SalesmanExists(salesman.SalesmanId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSalesman", new { id = salesman.SalesmanId }, salesman);
        }

        // DELETE: api/Salesmen/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSalesman(string id)
        {
            if (_context.Salesmen == null)
            {
                return NotFound();
            }
            var salesman = await _context.Salesmen.FindAsync(id);
            if (salesman == null)
            {
                return NotFound();
            }

            _context.Salesmen.Remove(salesman);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SalesmanExists(string id)
        {
            return (_context.Salesmen?.Any(e => e.SalesmanId == id)).GetValueOrDefault();
        }
    }
}
