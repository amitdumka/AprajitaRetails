using AprajitaRetails.Server.Data;
using AprajitaRetails.Shared.Models.Stores;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AprajitaRetails.Server.Controllers.Accounts
{
    [Route("api/[controller]")]
    [ApiController]
    public class DueRecoveriesController : ControllerBase
    {
        private readonly ARDBContext _context;
        private readonly IMapper _mapper;

        public DueRecoveriesController(ARDBContext context, IMapper mapper)
        {
            _context = context; _mapper = mapper;
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
        // GET: api/DueRecoveries
        [HttpGet("ByStore")]
        public async Task<ActionResult<IEnumerable<DueRecovery>>> GetDuesRecoveryByStore(string storeid)
        {
            if (_context.DuesRecovery == null)
            {
                return NotFound();
            }
            return await _context.DuesRecovery.Include(c=>c.Due).Where(c=>c.StoreId==storeid && c.OnDate.Year>=DateTime.Today.Year-1).OrderByDescending(c=>c.OnDate).ToListAsync();
        }
        // GET: api/DueRecoveries
        [HttpGet("ByStoreDTO")]
        public async Task<ActionResult<IEnumerable<DueRecovery>>> GetDuesRecoveryByStoreDTO(string storeid)
        {
            if (_context.DuesRecovery == null)
            {
                return NotFound();
            }
            return await _context.DuesRecovery.Include(c => c.Due).Where(c => c.StoreId == storeid && c.OnDate.Year >= DateTime.Today.Year - 1).OrderByDescending(c => c.OnDate).ToListAsync();
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



        public string GenerateID(DueRecovery rec) {


            DateTime dt = DateTime.Now;
            var x = _context.DuesRecovery.Count();
            string id = $"DR-{dt.Year}-{dt.Month}-{dt.Day}-{rec.StoreId}-{++x}";
            return id;
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

            dueRecovery.Id = GenerateID(dueRecovery);
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