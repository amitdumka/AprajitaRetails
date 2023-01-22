using AprajitaRetails.Server.BL.Payrolls;
using AprajitaRetails.Server.Data;
using AprajitaRetails.Shared.Models.Payroll;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using AprajitaRetails.Shared.AutoMapper.DTO;

namespace AprajitaRetails.Server.Controllers.Payroll
{
    [Route("[controller]")]
    [ApiController]
    public class AttendancesController : ControllerBase
    {
        private readonly ARDBContext _context;
        private readonly IMapper _mapper;
        public AttendancesController(ARDBContext context, IMapper mapper)
        {
            _context = context; _mapper = mapper;
        }

        // GET: api/Attendances
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Attendance>>> GetAttendance()
        {
            if (_context.Attendances == null)
            {
                return NotFound();
            }
            return await _context.Attendances.Where(c => c.OnDate.Year == DateTime.Today.Year)
                .OrderByDescending(c => c.OnDate)
                .ToListAsync();
        }
        [HttpGet("ByStoreDTO")]
        public async Task<ActionResult<IEnumerable<AttendanceDTO>>> GetAttendanceByStoreDTO(string storeid)
        {
            if (_context.Attendances == null)
            {
                return NotFound();
            }
            return await _context.Attendances.Include(c => c.Employee).Include(c => c.Store).Where(c => c.OnDate.Year == DateTime.Today.Year && c.StoreId == storeid)
                .OrderByDescending(c => c.OnDate).ProjectTo<AttendanceDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        [HttpGet("ByStore")]
        public async Task<ActionResult<IEnumerable<Attendance>>> GetAttendanceByStore(string storeid)
        {
            if (_context.Attendances == null)
            {
                return NotFound();
            }
            return await _context.Attendances.Where(c => c.OnDate.Year == DateTime.Today.Year && c.StoreId == storeid)
                .OrderByDescending(c => c.OnDate)
                .ToListAsync();
        }

        // GET: api/Attendances/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Attendance>> GetAttendance(string id)
        {
            if (_context.Attendances == null)
            {
                return NotFound();
            }
            var attendance = await _context.Attendances.FindAsync(id);


            if (attendance == null)
            {
                return NotFound();
            }
            attendance.Employee = await _context.Employees.FindAsync(attendance.EmployeeId);
            return attendance;
        }

        // PUT: api/Attendances/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAttendance(string id, Attendance attendance)
        {
            if (id != attendance.AttendanceId)
            {
                return BadRequest();
            }

            _context.Entry(attendance).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AttendanceExists(id))
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

        // POST: api/Attendances
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Attendance>> PostAttendance(Attendance attendance)
        {
            if (_context.Attendances == null)
            {
                return Problem("Entity set 'ARDBContext.Attendance'  is null.");
            }
            attendance.AttendanceId = PayrollHelper.AttendanceIdGenerator(attendance.EmployeeId, attendance.OnDate);
            _context.Attendances.Add(attendance);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AttendanceExists(attendance.AttendanceId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAttendance", new { id = attendance.AttendanceId }, attendance);
        }

        // DELETE: api/Attendances/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAttendance(string id)
        {
            if (_context.Attendances == null)
            {
                return NotFound();
            }
            var attendance = await _context.Attendances.FindAsync(id);
            if (attendance == null)
            {
                return NotFound();
            }

            _context.Attendances.Remove(attendance);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AttendanceExists(string id)
        {
            return (_context.Attendances?.Any(e => e.AttendanceId == id)).GetValueOrDefault();
        }
    }
}
