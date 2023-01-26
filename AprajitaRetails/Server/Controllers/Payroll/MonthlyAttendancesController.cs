using AprajitaRetails.Server.Data;
using AprajitaRetails.Shared.AutoMapper.DTO;
using AprajitaRetails.Shared.Models.Payroll;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace AprajitaRetails.Server.Controllers.Payroll
{
    [Route("[controller]")]
    [ApiController]
    public class MonthlyAttendancesController : ControllerBase
    {
        private readonly ARDBContext _context;
        private readonly IMapper _mapper;
        public MonthlyAttendancesController(ARDBContext context, IMapper mapper)
        {
            _context = context; _mapper = mapper;
        }

        // GET: api/MonthlyAttendances
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MonthlyAttendance>>> GetMonthlyAttendance()
        {
            if (_context.MonthlyAttendances == null)
            {
                return NotFound();
            }
            return await _context.MonthlyAttendances.ToListAsync();
        }

        // GET: api/MonthlyAttendances/ByStore
        [HttpGet("ByStore")]
        public async Task<ActionResult<IEnumerable<MonthlyAttendance>>> GetMonthlyAttendanceByStore(string storeid)
        {
            if (_context.MonthlyAttendances == null)
            {
                return NotFound();
            }
            return await _context.MonthlyAttendances.Where(c => c.OnDate.Year >= DateTime.Today.Year-1 && c.StoreId == storeid)
                .OrderByDescending(c => c.OnDate)
                .ToListAsync();
        }
        // GET: api/MonthlyAttendances/ByStore
        [HttpGet("ByStoreDTo")]
        public async Task<ActionResult<IEnumerable<MonthlyAttendanceDTO>>> GetMonthlyAttendanceByStoreDTO(string storeid)
        {
            if (_context.MonthlyAttendances == null)
            {
                return NotFound();
            }
            return await _context.MonthlyAttendances.Include(c => c.Employee).Include(c => c.Store).Where(c => c.OnDate.Year >= DateTime.Today.Year-1 && c.StoreId == storeid)
                .OrderByDescending(c => c.OnDate).ProjectTo<MonthlyAttendanceDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }



        // GET: api/MonthlyAttendances/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MonthlyAttendance>> GetMonthlyAttendance(string id)
        {
            if (_context.MonthlyAttendances == null)
            {
                return NotFound();
            }
            var monthlyAttendance = await _context.MonthlyAttendances.FindAsync(id);

            if (monthlyAttendance == null)
            {
                return NotFound();
            }

            return monthlyAttendance;
        }

        // PUT: api/MonthlyAttendances/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMonthlyAttendance(string id, MonthlyAttendance monthlyAttendance)
        {
            if (id != monthlyAttendance.MonthlyAttendanceId)
            {
                return BadRequest();
            }

            _context.Entry(monthlyAttendance).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MonthlyAttendanceExists(id))
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

        // POST: api/MonthlyAttendances
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MonthlyAttendance>> PostMonthlyAttendance(MonthlyAttendance monthlyAttendance)
        {
            if (_context.MonthlyAttendances == null)
            {
                return Problem("Entity set 'ARDBContext.MonthlyAttendance'  is null.");
            }
            _context.MonthlyAttendances.Add(monthlyAttendance);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MonthlyAttendanceExists(monthlyAttendance.MonthlyAttendanceId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMonthlyAttendance", new { id = monthlyAttendance.MonthlyAttendanceId }, monthlyAttendance);
        }

        // DELETE: api/MonthlyAttendances/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMonthlyAttendance(string id)
        {
            if (_context.MonthlyAttendances == null)
            {
                return NotFound();
            }
            var monthlyAttendance = await _context.MonthlyAttendances.FindAsync(id);
            if (monthlyAttendance == null)
            {
                return NotFound();
            }

            _context.MonthlyAttendances.Remove(monthlyAttendance);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MonthlyAttendanceExists(string id)
        {
            return (_context.MonthlyAttendances?.Any(e => e.MonthlyAttendanceId == id)).GetValueOrDefault();
        }
    }
}
