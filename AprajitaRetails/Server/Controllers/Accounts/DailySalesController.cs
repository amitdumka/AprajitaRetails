using AprajitaRetails.Server.Data;
using AprajitaRetails.Shared.AutoMapper.DTO;
using AprajitaRetails.Shared.Models.Stores;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AprajitaRetails.Server.Controllers.Accounts
{
    [Route("[controller]")]
    [ApiController]
    public class DailySalesController : ControllerBase
    {
        private readonly ARDBContext _context; private readonly IMapper _mapper;

        public DailySalesController(ARDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/DailySales
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DailySale>>> GetDailySales()
        {
            if (_context.DailySales == null)
            {
                return NotFound();
            }
            return await _context.DailySales.Where(c => c.OnDate.Year > (DateTime.Now.Year - 2)).ToListAsync();
        }
        // GET: api/DailySales
        [HttpGet("ByStoreDTO")]
        public async Task<ActionResult<IEnumerable<DailySaleDTO>>> GetDailySalesByStoreDTO(string storeid)
        {
            if (_context.DailySales == null)
            {
                return NotFound();
            }
            return await _context.DailySales.Include(c => c.Store).Include(c => c.EDC).Include(c => c.Salesman).Where(c => c.StoreId == storeid && c.OnDate.Year >= (DateTime.Today.Year - 1)).OrderByDescending(c => c.OnDate)
                .ProjectTo<DailySaleDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        // GET: api/DailySales/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DailySale>> GetDailySale(string id)
        {
            if (_context.DailySales == null)
            {
                return NotFound();
            }
            var dailySale = await _context.DailySales.FindAsync(id);

            if (dailySale == null)
            {
                return NotFound();
            }

            return dailySale;
        }

        // PUT: api/DailySales/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDailySale(string id, DailySale dailySale)
        {
            if (id != dailySale.InvoiceNumber)
            {
                return BadRequest();
            }

            _context.Entry(dailySale).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DailySaleExists(id))
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

        // POST: api/DailySales
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DailySale>> PostDailySale(DailySale dailySale)
        {
            if (_context.DailySales == null)
            {
                return Problem("Entity set 'ARDBContext.DailySales'  is null.");
            }
            _context.DailySales.Add(dailySale);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DailySaleExists(dailySale.InvoiceNumber))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDailySale", new { id = dailySale.InvoiceNumber }, dailySale);
        }

        // DELETE: api/DailySales/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDailySale(string id)
        {
            if (_context.DailySales == null)
            {
                return NotFound();
            }
            var dailySale = await _context.DailySales.FindAsync(id);
            if (dailySale == null)
            {
                return NotFound();
            }

            _context.DailySales.Remove(dailySale);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DailySaleExists(string id)
        {
            return (_context.DailySales?.Any(e => e.InvoiceNumber == id)).GetValueOrDefault();
        }
    }
}