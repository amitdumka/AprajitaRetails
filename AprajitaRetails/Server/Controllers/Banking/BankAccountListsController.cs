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
    public class BankAccountListsController : ControllerBase
    {
        private readonly ARDBContext _context;

        public BankAccountListsController(ARDBContext context)
        {
            _context = context;
        }

        // GET: api/BankAccountLists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BankAccountList>>> GetAccountLists()
        {
          if (_context.AccountLists == null)
          {
              return NotFound();
          }
            return await _context.AccountLists.ToListAsync();
        }

        // GET: api/BankAccountLists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BankAccountList>> GetBankAccountList(string id)
        {
          if (_context.AccountLists == null)
          {
              return NotFound();
          }
            var bankAccountList = await _context.AccountLists.FindAsync(id);

            if (bankAccountList == null)
            {
                return NotFound();
            }

            return bankAccountList;
        }

        // PUT: api/BankAccountLists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBankAccountList(string id, BankAccountList bankAccountList)
        {
            if (id != bankAccountList.AccountNumber)
            {
                return BadRequest();
            }

            _context.Entry(bankAccountList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BankAccountListExists(id))
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

        // POST: api/BankAccountLists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BankAccountList>> PostBankAccountList(BankAccountList bankAccountList)
        {
          if (_context.AccountLists == null)
          {
              return Problem("Entity set 'ARDBContext.AccountLists'  is null.");
          }
            _context.AccountLists.Add(bankAccountList);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BankAccountListExists(bankAccountList.AccountNumber))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBankAccountList", new { id = bankAccountList.AccountNumber }, bankAccountList);
        }

        // DELETE: api/BankAccountLists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBankAccountList(string id)
        {
            if (_context.AccountLists == null)
            {
                return NotFound();
            }
            var bankAccountList = await _context.AccountLists.FindAsync(id);
            if (bankAccountList == null)
            {
                return NotFound();
            }

            _context.AccountLists.Remove(bankAccountList);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BankAccountListExists(string id)
        {
            return (_context.AccountLists?.Any(e => e.AccountNumber == id)).GetValueOrDefault();
        }
    }
}
