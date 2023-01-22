using AprajitaRetails.Server.Data;
using AprajitaRetails.Shared.Models.Payroll;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using AutoMapper.QueryableExtensions;
namespace AprajitaRetails.Server.Controllers.Payroll
{
    [Route("[controller]")]
    [ApiController]
    public class PaySlipsController : ControllerBase
    {
        private readonly ARDBContext _context;
        private readonly IMapper _mapper;
        public PaySlipsController(ARDBContext context, IMapper mapper)
        {
            _context = context; _mapper = mapper;
        }

        // GET: api/PaySlips
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaySlip>>> GetPaySlip()
        {
            if (_context.PaySlips == null)
            {
                return NotFound();
            }
            return await _context.PaySlips.ToListAsync();
        }

        // GET: api/PaySlips/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PaySlip>> GetPaySlip(string id)
        {
            if (_context.PaySlips == null)
            {
                return NotFound();
            }
            var paySlip = await _context.PaySlips.FindAsync(id);

            if (paySlip == null)
            {
                return NotFound();
            }

            return paySlip;
        }

        // PUT: api/PaySlips/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaySlip(string id, PaySlip paySlip)
        {
            if (id != paySlip.PaySlipId)
            {
                return BadRequest();
            }

            _context.Entry(paySlip).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaySlipExists(id))
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

        // POST: api/PaySlips
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PaySlip>> PostPaySlip(PaySlip paySlip)
        {
            if (_context.PaySlips == null)
            {
                return Problem("Entity set 'ARDBContext.PaySlip'  is null.");
            }
            _context.PaySlips.Add(paySlip);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PaySlipExists(paySlip.PaySlipId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPaySlip", new { id = paySlip.PaySlipId }, paySlip);
        }

        // DELETE: api/PaySlips/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaySlip(string id)
        {
            if (_context.PaySlips == null)
            {
                return NotFound();
            }
            var paySlip = await _context.PaySlips.FindAsync(id);
            if (paySlip == null)
            {
                return NotFound();
            }

            _context.PaySlips.Remove(paySlip);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PaySlipExists(string id)
        {
            return (_context.PaySlips?.Any(e => e.PaySlipId == id)).GetValueOrDefault();
        }
    }
}
