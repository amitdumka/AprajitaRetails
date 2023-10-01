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
    public class StaffAdvanceReceiptsController : ControllerBase
    {
        private readonly ARDBContext _context;
        private readonly IMapper _mapper;
        public StaffAdvanceReceiptsController(ARDBContext context, IMapper mapper)
        {
            _context = context; _mapper = mapper;
        }

        // GET: api/StaffAdvanceReceipts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StaffAdvanceReceipt>>> GetStaffAdvanceReceipt()
        {
            if (_context.StaffAdvanceReceipts == null)
            {
                return NotFound();
            }
            return await _context.StaffAdvanceReceipts.ToListAsync();
        }
        [HttpGet("ByStoreDTO")]
        public async Task<ActionResult<IEnumerable<StaffAdvanceReceiptDTO>>> GetStaffAdvanceReceiptByStoreDTO(string storeid)
        {
            if (_context.StaffAdvanceReceipts == null)
            {
                return NotFound();
            }
            return await _context.StaffAdvanceReceipts.Include(c => c.Employee).Include(c => c.Store).Where(c => c.OnDate.Year == DateTime.Today.Year && c.StoreId == storeid)
                .OrderByDescending(c => c.OnDate).ProjectTo<StaffAdvanceReceiptDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }
        // GET: api/StaffAdvanceReceipts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StaffAdvanceReceipt>> GetStaffAdvanceReceipt(string id)
        {
            if (_context.StaffAdvanceReceipts == null)
            {
                return NotFound();
            }
            var staffAdvanceReceipt = await _context.StaffAdvanceReceipts.FindAsync(id);

            if (staffAdvanceReceipt == null)
            {
                return NotFound();
            }

            return staffAdvanceReceipt;
        }

        // PUT: api/StaffAdvanceReceipts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStaffAdvanceReceipt(string id, StaffAdvanceReceipt staffAdvanceReceipt)
        {
            if (id != staffAdvanceReceipt.StaffAdvanceReceiptId)
            {
                return BadRequest();
            }

            _context.Entry(staffAdvanceReceipt).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StaffAdvanceReceiptExists(id))
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

        // POST: api/StaffAdvanceReceipts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StaffAdvanceReceipt>> PostStaffAdvanceReceipt(StaffAdvanceReceipt staffAdvanceReceipt)
        {
            if (_context.StaffAdvanceReceipts == null)
            {
                return Problem("Entity set 'ARDBContext.StaffAdvanceReceipt'  is null.");
            }
            _context.StaffAdvanceReceipts.Add(staffAdvanceReceipt);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (StaffAdvanceReceiptExists(staffAdvanceReceipt.StaffAdvanceReceiptId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetStaffAdvanceReceipt", new { id = staffAdvanceReceipt.StaffAdvanceReceiptId }, staffAdvanceReceipt);
        }

        // DELETE: api/StaffAdvanceReceipts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStaffAdvanceReceipt(string id)
        {
            if (_context.StaffAdvanceReceipts == null)
            {
                return NotFound();
            }
            var staffAdvanceReceipt = await _context.StaffAdvanceReceipts.FindAsync(id);
            if (staffAdvanceReceipt == null)
            {
                return NotFound();
            }

            _context.StaffAdvanceReceipts.Remove(staffAdvanceReceipt);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StaffAdvanceReceiptExists(string id)
        {
            return (_context.StaffAdvanceReceipts?.Any(e => e.StaffAdvanceReceiptId == id)).GetValueOrDefault();
        }
    }
}
