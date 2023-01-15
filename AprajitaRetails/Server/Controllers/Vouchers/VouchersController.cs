using AprajitaRetails.Server.BL.Accounts;
using AprajitaRetails.Server.Data;
using AprajitaRetails.Shared.Models.Vouchers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AprajitaRetails.Server.Controllers.Vouchers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    // [Route("[controller]")]
    public class VouchersController : ControllerBase
    {
        private readonly ARDBContext _context;

        public VouchersController(ARDBContext context)
        {
            _context = context;
        }

        // GET: api/Vouchers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Voucher>>> GetVoucher()
        {
            if (_context.Vouchers == null)
            {
                return NotFound();
            }
            return await _context.Vouchers.OrderByDescending(c => c.OnDate).ToListAsync();
        }
        // GET: api/Vouchers
        [HttpGet("ByStore")]
        public async Task<ActionResult<IEnumerable<Voucher>>> GetVoucherByStore(string storeid)
        {
            if (_context.Vouchers == null)
            {
                return NotFound();
            }
            return await _context.Vouchers.Where(c => c.StoreId == storeid && c.OnDate.Year == DateTime.Today.Year).OrderByDescending(c => c.OnDate).ToListAsync();
        }

        // GET: api/Vouchers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Voucher>> GetVoucher(string id)
        {
            if (_context.Vouchers == null)
            {
                return NotFound();
            }
            var voucher = await _context.Vouchers.FindAsync(id);

            if (voucher == null)
            {
                return NotFound();
            }

            return voucher;
        }

        // PUT: api/Vouchers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVoucher(string id, Voucher voucher)
        {
            if (id != voucher.VoucherNumber)
            {
                return BadRequest();
            }

            _context.Entry(voucher).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VoucherExists(id))
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

        // POST: api/Vouchers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Voucher>> PostVoucher(Voucher voucher)
        {
            if (_context.Vouchers == null)
            {
                return Problem("Entity set 'ARDBContext.Voucher'  is null.");
            }
            // Adding VoucherNumber
            voucher.VoucherNumber = AccountHelper.VoucherNumberGenerator(_context, voucher.VoucherType, voucher.StoreId, voucher.OnDate);

            _context.Vouchers.Add(voucher);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (VoucherExists(voucher.VoucherNumber))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetVoucher", new { id = voucher.VoucherNumber }, voucher);
        }

        // DELETE: api/Vouchers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVoucher(string id)
        {
            if (_context.Vouchers == null)
            {
                return NotFound();
            }
            var voucher = await _context.Vouchers.FindAsync(id);
            if (voucher == null)
            {
                return NotFound();
            }

            _context.Vouchers.Remove(voucher);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VoucherExists(string id)
        {
            return (_context.Vouchers?.Any(e => e.VoucherNumber == id)).GetValueOrDefault();
        }
    }
}
