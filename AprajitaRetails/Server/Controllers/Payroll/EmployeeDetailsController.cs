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
    public class EmployeeDetailsController : ControllerBase
    {
        private readonly ARDBContext _context;
        private readonly IMapper _mapper;
        public EmployeeDetailsController(ARDBContext context, IMapper mapper)
        {
            _context = context; _mapper = mapper;
        }

        // GET: api/EmployeeDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDetails>>> GetEmployeeDetails()
        {
            if (_context.EmployeeDetails == null)
            {
                return NotFound();
            }
            return await _context.EmployeeDetails.ToListAsync();
        }
        // GET: api/EmployeeDetails
        [HttpGet("ByStoreDTO")]
        public async Task<ActionResult<IEnumerable<EmployeeDetailsDTO>>> GetEmployeeDetailsByStoreDTO(string storeid)
        {
            if (_context.EmployeeDetails == null)
            {
                return NotFound();
            }
            return await _context.EmployeeDetails.Include(c => c.Employee).Include(c => c.Store).Where(c => c.StoreId == storeid).ProjectTo<EmployeeDetailsDTO>(_mapper.ConfigurationProvider).ToListAsync();
        }
        // GET: api/EmployeeDetails
        [HttpGet("ByStore")]
        public async Task<ActionResult<IEnumerable<EmployeeDetails>>> GetEmployeeDetailsByStore(string storeid)
        {
            if (_context.EmployeeDetails == null)
            {
                return NotFound();
            }
            return await _context.EmployeeDetails.Include(c => c.Employee).Where(c => c.StoreId == storeid).ToListAsync();
        }
        // GET: api/EmployeeDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDetails>> GetEmployeeDetails(string id)
        {
            if (_context.EmployeeDetails == null)
            {
                return NotFound();
            }
            var employeeDetails = await _context.EmployeeDetails.FindAsync(id);

            if (employeeDetails == null)
            {
                return NotFound();
            }

            return employeeDetails;
        }

        // PUT: api/EmployeeDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeeDetails(string id, EmployeeDetails employeeDetails)
        {
            if (id != employeeDetails.EmployeeId)
            {
                return BadRequest();
            }

            _context.Entry(employeeDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeDetailsExists(id))
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

        // POST: api/EmployeeDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EmployeeDetails>> PostEmployeeDetails(EmployeeDetails employeeDetails)
        {
            if (_context.EmployeeDetails == null)
            {
                return Problem("Entity set 'ARDBContext.EmployeeDetails'  is null.");
            }
            _context.EmployeeDetails.Add(employeeDetails);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EmployeeDetailsExists(employeeDetails.EmployeeId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEmployeeDetails", new { id = employeeDetails.EmployeeId }, employeeDetails);
        }

        // DELETE: api/EmployeeDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeDetails(string id)
        {
            if (_context.EmployeeDetails == null)
            {
                return NotFound();
            }
            var employeeDetails = await _context.EmployeeDetails.FindAsync(id);
            if (employeeDetails == null)
            {
                return NotFound();
            }

            _context.EmployeeDetails.Remove(employeeDetails);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeeDetailsExists(string id)
        {
            return (_context.EmployeeDetails?.Any(e => e.EmployeeId == id)).GetValueOrDefault();
        }

        [HttpGet("NewEmployeeList")]
        public async Task<ActionResult<IEnumerable<string>>> GetNewEmployeeList(string storeid)
        {
            if (_context.Employees == null)
            {
                return NotFound();
            }

            var list = await _context.Employees.Where(c => c.StoreId == storeid).OrderByDescending(c => c.JoiningDate).Select(c => c.EmployeeId).ToListAsync();
            var a = await _context.EmployeeDetails.Where(c => c.StoreId == storeid).Select(c => c.EmployeeId).ToListAsync();
            var flist = list.Except(a).ToList(); ;
            return flist;
        }
    }
}
