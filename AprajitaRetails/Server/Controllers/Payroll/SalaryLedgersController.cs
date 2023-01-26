using AprajitaRetails.Server.Data;
using AprajitaRetails.Shared.Models.Payroll;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace AprajitaRetails.Server.Controllers.Payroll
{
    [Route("[controller]")]
    [ApiController]
    public class SalaryLedgersController : ControllerBase
    {
        private readonly ARDBContext _context;
        private readonly IMapper _mapper;
        public SalaryLedgersController(ARDBContext context, IMapper mapper)
        {
            _context = context; _mapper = mapper;
        }

        // GET: api/SalaryLedgers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SalaryLedger>>> GetSalaryLedger()
        {
            if (_context.SalaryLedgers == null)
            {
                return NotFound();
            }
            return await _context.SalaryLedgers.ToListAsync();
        }

        // GET: api/SalaryLedgers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SalaryLedger>> GetSalaryLedger(int id)
        {
            if (_context.SalaryLedgers == null)
            {
                return NotFound();
            }
            var salaryLedger = await _context.SalaryLedgers.FindAsync(id);

            if (salaryLedger == null)
            {
                return NotFound();
            }

            return salaryLedger;
        }

        // PUT: api/SalaryLedgers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSalaryLedger(int id, SalaryLedger salaryLedger)
        {
            if (id != salaryLedger.Id)
            {
                return BadRequest();
            }

            _context.Entry(salaryLedger).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalaryLedgerExists(id))
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

        // POST: api/SalaryLedgers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SalaryLedger>> PostSalaryLedger(SalaryLedger salaryLedger)
        {
            if (_context.SalaryLedgers == null)
            {
                return Problem("Entity set 'ARDBContext.SalaryLedger'  is null.");
            }
            _context.SalaryLedgers.Add(salaryLedger);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSalaryLedger", new { id = salaryLedger.Id }, salaryLedger);
        }

        // DELETE: api/SalaryLedgers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSalaryLedger(int id)
        {
            if (_context.SalaryLedgers == null)
            {
                return NotFound();
            }
            var salaryLedger = await _context.SalaryLedgers.FindAsync(id);
            if (salaryLedger == null)
            {
                return NotFound();
            }

            _context.SalaryLedgers.Remove(salaryLedger);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SalaryLedgerExists(int id)
        {
            return (_context.SalaryLedgers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
