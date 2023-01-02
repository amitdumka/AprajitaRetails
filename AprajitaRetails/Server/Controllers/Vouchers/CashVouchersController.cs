using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AprajitaRetails.Server.Data;
using AprajitaRetails.Shared.Models.Vouchers;
using Microsoft.AspNetCore.Authorization;
using AprajitaRetails.Server.BL.Accounts;

namespace AprajitaRetails.Server.Controllers.Vouchers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    //[Route("[controller]")]
    //[ApiController]
    public class CashVouchersController : ControllerBase
    {
        private readonly ARDBContext _context;

        public CashVouchersController(ARDBContext context)
        {
            _context = context;
        }

        // GET: api/CashVouchers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CashVoucher>>> GetCashVouchers()
        {
            if (_context.CashVouchers == null)
            {
                return NotFound();
            }
            return await _context.CashVouchers.ToListAsync();
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
