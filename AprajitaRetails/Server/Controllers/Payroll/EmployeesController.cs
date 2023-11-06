using AprajitaRetails.Server.BL.Payrolls;
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
    public class EmployeesController : ControllerBase
    {
        private readonly ARDBContext _context;
        private readonly IMapper _mapper;
        public EmployeesController(ARDBContext context, IMapper mapper)
        {
            _context = context; _mapper = mapper;
        }

        // GET: api/Employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            if (_context.Employees == null)
            {
                return NotFound();
            }
            return await _context.Employees.ToListAsync();
        }

        [HttpGet("ByStoreDTO")]
        public async Task<ActionResult<IEnumerable<EmployeeDTO>>> GetEmployeesByStoreDTO(string storeid, bool isWorking = true)
        {
            if (_context.Employees == null)
            {
                return NotFound();
            }
            if (isWorking)
                return await _context.Employees.Include(c => c.Store).Where(c => c.StoreId == storeid && c.IsWorking)
                    .ProjectTo<EmployeeDTO>(_mapper.ConfigurationProvider).ToListAsync();
            else
                return await _context.Employees.Include(c => c.Store).Where(c => c.StoreId == storeid)
                    .ProjectTo<EmployeeDTO>(_mapper.ConfigurationProvider)
                    .ToListAsync();
        }
        [HttpGet("ByStore")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployeesByStore(string storeid, bool isWorking = true)
        {
            if (_context.Employees == null)
            {
                return NotFound();
            }
            if (isWorking)
                return await _context.Employees.Where(c => c.StoreId == storeid && c.IsWorking).ToListAsync();
            else
                return await _context.Employees.Where(c => c.StoreId == storeid).ToListAsync();
        }

        // GET: api/Employees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(string id)
        {
            if (_context.Employees == null)
            {
                return NotFound();
            }
            var employee = await _context.Employees.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        // PUT: api/Employees/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(string id, Employee employee)
        {
            if (id != employee.EmployeeId)
            {
                return BadRequest();
            }

            _context.Entry(employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
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

        // POST: api/Employees
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
            if (_context.Employees == null)
            {
                return Problem("Entity set 'ARDBContext.Employees'  is null.");
            }
            employee.EmpId = _context.Employees.Count() + 1;
            employee.EmployeeId = $"{PayrollHelper.EmployeeIdGenerator(employee.StoreId, employee.JoiningDate.Year, employee.Category)}-{employee.EmpId}";
            
            _context.Employees.Add(employee);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EmployeeExists(employee.EmployeeId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEmployee", new { id = employee.EmployeeId }, employee);
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(string id)
        {
            if (_context.Employees == null)
            {
                return NotFound();
            }
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeeExists(string id)
        {
            return (_context.Employees?.Any(e => e.EmployeeId == id)).GetValueOrDefault();
        }
    }
}
