using AprajitaRetails.Server.BL.Accounts;
using AprajitaRetails.Server.Data;
using AprajitaRetails.Shared.AutoMapper.DTO;
using AprajitaRetails.Shared.Models.Vouchers;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Syncfusion.Blazor.Diagrams;
using System.Collections.Generic;

namespace AprajitaRetails.Server.Controllers.Vouchers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class CashVouchersController : ControllerBase
    {
        private readonly ARDBContext _context;
        private readonly IMapper _mapper;

        public CashVouchersController(ARDBContext context, IMapper mapper)
        {
            _context = context; _mapper = mapper;
        }

        // GET: api/CashVouchers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CashVoucher>>> GetCashVouchers()
        {
            if (_context.CashVouchers == null)
            {
                return NotFound();
            }
            return await _context.CashVouchers.OrderByDescending(c => c.OnDate).ToListAsync();
        }

        // GET: api/CashVouchers
        [HttpGet("ByStore")]
        public async Task<ActionResult<IEnumerable<CashVoucher>>> GetCashVouchersByStore(string storeid)
        {
            if (_context.CashVouchers == null)
            {
                return NotFound();
            }
            return await _context.CashVouchers.Where(c => c.StoreId == storeid && c.OnDate.Year >= (DateTime.Today.Year - 1))
                .OrderByDescending(c => c.OnDate).ToListAsync();
        }

        [HttpGet("ByStoreDTO")]
        public async Task<ActionResult<IEnumerable<CashVoucherDTO>>> GetCashVouchersByStoreDTO(string storeid)
        {
            if (_context.CashVouchers == null)
            {
                return NotFound();
            }
            return await _context.CashVouchers.Include(c => c.Store).Include(c => c.TransactionMode).Include(c => c.Partys)
                .Include(c => c.Employee)
                .Where(c => c.StoreId == storeid && c.OnDate.Year >= (DateTime.Today.Year - 1))
                .OrderByDescending(c => c.OnDate).ProjectTo<CashVoucherDTO>(_mapper.ConfigurationProvider).ToListAsync();
        }

        // GET: api/CashVouchers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CashVoucher>> GetCashVoucher(string id)
        {
            if (_context.CashVouchers == null)
            {
                return NotFound();
            }
            var cashVoucher = await _context.CashVouchers.FindAsync(id);

            if (cashVoucher == null)
            {
                return NotFound();
            }

            return cashVoucher;
        }

        // PUT: api/CashVouchers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCashVoucher(string id, CashVoucher cashVoucher)
        {
            if (id != cashVoucher.VoucherNumber)
            {
                return BadRequest();
            }

            _context.Entry(cashVoucher).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CashVoucherExists(id))
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

        // POST: api/CashVouchers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CashVoucher>> PostCashVoucher(CashVoucher cashVoucher)
        {
            if (_context.CashVouchers == null)
            {
                return Problem("Entity set 'ARDBContext.CashVouchers'  is null.");
            }
            // Adding VoucherNumber
            cashVoucher.VoucherNumber = AccountHelper.VoucherNumberGenerator(_context, cashVoucher.VoucherType, cashVoucher.StoreId, cashVoucher.OnDate);

            _context.CashVouchers.Add(cashVoucher);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CashVoucherExists(cashVoucher.VoucherNumber))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCashVoucher", new { id = cashVoucher.VoucherNumber }, cashVoucher);
        }

        // DELETE: api/CashVouchers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCashVoucher(string id)
        {
            if (_context.CashVouchers == null)
            {
                return NotFound();
            }
            var cashVoucher = await _context.CashVouchers.FindAsync(id);
            if (cashVoucher == null)
            {
                return NotFound();
            }

            _context.CashVouchers.Remove(cashVoucher);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CashVoucherExists(string id)
        {
            return (_context.CashVouchers?.Any(e => e.VoucherNumber == id)).GetValueOrDefault();
        }
    }
}