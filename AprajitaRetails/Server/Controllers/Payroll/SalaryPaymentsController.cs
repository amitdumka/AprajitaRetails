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
    public class SalaryPaymentsController : ControllerBase
    {
        private readonly ARDBContext _context;
        private readonly IMapper _mapper;
        public SalaryPaymentsController(ARDBContext context, IMapper mapper)
        {
            _context = context; _mapper = mapper;
        }

        // GET: api/SalaryPayments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SalaryPayment>>> GetSalaryPayment()
        {
            if (_context.SalaryPayments == null)
            {
                return NotFound();
            }
            return await _context.SalaryPayments.OrderByDescending(c => c.OnDate).ToListAsync();
        }
        // GET: api/SalaryPayments/ByStore
        [HttpGet("ByStore")]
        public async Task<ActionResult<IEnumerable<SalaryPayment>>> GetSalaryPaymentByStore(string storeid)
        {
            if (_context.SalaryPayments == null)
            {
                return NotFound();
            }
            return await _context.SalaryPayments.Where(c => c.StoreId == storeid && c.OnDate.Year >= DateTime.Today.Year - 1).OrderByDescending(c => c.OnDate).ToListAsync();
        }
        // GET: api/SalaryPayments/ByStore
        [HttpGet("ByStoreDTO")]
        public async Task<ActionResult<IEnumerable<SalaryPaymentDTO>>> GetSalaryPaymentByStoreDTO(string storeid)
        {
            if (_context.SalaryPayments == null)
            {
                return NotFound();
            }
            return await _context.SalaryPayments.Include(c => c.Employee).Include(c => c.Store).Where(c => c.OnDate.Year >= DateTime.Today.Year - 1 && c.StoreId == storeid)
                .OrderByDescending(c => c.OnDate).ProjectTo<SalaryPaymentDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }
        // GET: api/SalaryPayments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SalaryPayment>> GetSalaryPayment(string id)
        {
            if (_context.SalaryPayments == null)
            {
                return NotFound();
            }
            var salaryPayment = await _context.SalaryPayments.FindAsync(id);

            if (salaryPayment == null)
            {
                return NotFound();
            }

            return salaryPayment;
        }

        // PUT: api/SalaryPayments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSalaryPayment(string id, SalaryPayment salaryPayment)
        {
            if (id != salaryPayment.SalaryPaymentId)
            {
                return BadRequest();
            }

            _context.Entry(salaryPayment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalaryPaymentExists(id))
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

        // POST: api/SalaryPayments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SalaryPayment>> PostSalaryPayment(SalaryPayment salaryPayment)
        {
            if (_context.SalaryPayments == null)
            {
                return Problem("Entity set 'ARDBContext.SalaryPayment'  is null.");
            }

            int count = _context.SalaryPayments.Where(c => c.OnDate.Year == salaryPayment.OnDate.Year && c.OnDate.Month == salaryPayment.OnDate.Month).Count() + 1;

            salaryPayment.SalaryPaymentId = PayrollHelper.GenerateSalaryPayment(salaryPayment.OnDate, salaryPayment.StoreId, count);

            _context.SalaryPayments.Add(salaryPayment);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SalaryPaymentExists(salaryPayment.SalaryPaymentId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSalaryPayment", new { id = salaryPayment.SalaryPaymentId }, salaryPayment);
        }

        // DELETE: api/SalaryPayments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSalaryPayment(string id)
        {
            if (_context.SalaryPayments == null)
            {
                return NotFound();
            }
            var salaryPayment = await _context.SalaryPayments.FindAsync(id);
            if (salaryPayment == null)
            {
                return NotFound();
            }

            _context.SalaryPayments.Remove(salaryPayment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SalaryPaymentExists(string id)
        {
            return (_context.SalaryPayments?.Any(e => e.SalaryPaymentId == id)).GetValueOrDefault();
        }
    }
}
