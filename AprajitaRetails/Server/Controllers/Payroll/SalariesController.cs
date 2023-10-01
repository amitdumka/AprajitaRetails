using AprajitaRetails.Server.Data;
using AprajitaRetails.Shared.AutoMapper.DTO;
using AprajitaRetails.Shared.Models.Payroll;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace AprajitaRetails.Server.Controllers.Payroll
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalariesController : ControllerBase
    {
        private readonly ARDBContext _context;
        private readonly IMapper _mapper;
        public SalariesController(ARDBContext context, IMapper mapper)
        {
            _context = context; _mapper = mapper;
        }

        // GET: api/Salaries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Salary>>> GetSalary()
        {
            if (_context.Salaries == null)
            {
                return NotFound();
            }
            return await _context.Salaries.ToListAsync();
        }
        [HttpGet("ByStoreDTO")]
        public async Task<ActionResult<IEnumerable<SalaryDTO>>> GetSalaryByStoreDTO(string storeid)
        {
            if (_context.Salaries == null)
            {
                return NotFound();
            }
            return await _context.Salaries.Include(c => c.Employee).Include(c => c.Store).Where(c => c.IsEffective && c.StoreId == storeid)
                .OrderByDescending(c => c.EffectiveDate).ProjectTo<SalaryDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        // GET: api/Salaries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Salary>> GetSalary(string id)
        {
            if (_context.Salaries == null)
            {
                return NotFound();
            }
            var salary = await _context.Salaries.FindAsync(id);

            if (salary == null)
            {
                return NotFound();
            }

            return salary;
        }

        // PUT: api/Salaries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSalary(string id, Salary salary)
        {
            if (id != salary.SalaryId)
            {
                return BadRequest();
            }

            _context.Entry(salary).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalaryExists(id))
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

        // POST: api/Salaries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Salary>> PostSalary(Salary salary)
        {
            if (_context.Salaries == null)
            {
                return Problem("Entity set 'ARDBContext.Salary'  is null.");
            }
            _context.Salaries.Add(salary);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SalaryExists(salary.SalaryId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSalary", new { id = salary.SalaryId }, salary);
        }

        // DELETE: api/Salaries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSalary(string id)
        {
            if (_context.Salaries == null)
            {
                return NotFound();
            }
            var salary = await _context.Salaries.FindAsync(id);
            if (salary == null)
            {
                return NotFound();
            }

            _context.Salaries.Remove(salary);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SalaryExists(string id)
        {
            return (_context.Salaries?.Any(e => e.SalaryId == id)).GetValueOrDefault();
        }
    }
}
