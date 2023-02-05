using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AprajitaRetails.Server.Data;
using AprajitaRetails.Shared.Models.Banking;

namespace AprajitaRetails.Server.Controllers.Banking
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorBankAccountsController : ControllerBase
    {
        private readonly ARDBContext _context;

        public VendorBankAccountsController(ARDBContext context)
        {
            _context = context;
        }

        // GET: api/VendorBankAccounts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VendorBankAccount>>> GetVendorBankAccounts()
        {
          if (_context.VendorBankAccounts == null)
          {
              return NotFound();
          }
            return await _context.VendorBankAccounts.ToListAsync();
        }

        [HttpGet("ByStore")]
        public async Task<ActionResult<IEnumerable<VendorBankAccount>>> GetVendorBankAccountsByStore(string storeid)
        {
            if (_context.VendorBankAccounts == null)
            {
                return NotFound();
            }
            return await _context.VendorBankAccounts.Include(c=>c.Bank).Where(c=>c.StoreId==storeid && !c.MarkedDeleted)
                .ToListAsync();
        }
        // GET: api/VendorBankAccounts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VendorBankAccount>> GetVendorBankAccount(string id)
        {
          if (_context.VendorBankAccounts == null)
          {
              return NotFound();
          }
            var vendorBankAccount = await _context.VendorBankAccounts.FindAsync(id);

            if (vendorBankAccount == null)
            {
                return NotFound();
            }

            return vendorBankAccount;
        }

        // PUT: api/VendorBankAccounts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVendorBankAccount(string id, VendorBankAccount vendorBankAccount)
        {
            if (id != vendorBankAccount.AccountNumber)
            {
                return BadRequest();
            }

            _context.Entry(vendorBankAccount).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VendorBankAccountExists(id))
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

        // POST: api/VendorBankAccounts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<VendorBankAccount>> PostVendorBankAccount(VendorBankAccount vendorBankAccount)
        {
          if (_context.VendorBankAccounts == null)
          {
              return Problem("Entity set 'ARDBContext.VendorBankAccounts'  is null.");
          }
            _context.VendorBankAccounts.Add(vendorBankAccount);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (VendorBankAccountExists(vendorBankAccount.AccountNumber))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetVendorBankAccount", new { id = vendorBankAccount.AccountNumber }, vendorBankAccount);
        }

        // DELETE: api/VendorBankAccounts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVendorBankAccount(string id)
        {
            if (_context.VendorBankAccounts == null)
            {
                return NotFound();
            }
            var vendorBankAccount = await _context.VendorBankAccounts.FindAsync(id);
            if (vendorBankAccount == null)
            {
                return NotFound();
            }

            _context.VendorBankAccounts.Remove(vendorBankAccount);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VendorBankAccountExists(string id)
        {
            return (_context.VendorBankAccounts?.Any(e => e.AccountNumber == id)).GetValueOrDefault();
        }
    }
}
