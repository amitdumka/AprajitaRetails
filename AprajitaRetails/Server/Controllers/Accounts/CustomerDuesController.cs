using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AprajitaRetails.Server.Data;
using AprajitaRetails.Shared.Models.Stores;

namespace AprajitaRetails.Server.Controllers.Accounts
{
    [Route("[controller]")]
    [ApiController]
    public class CustomerDuesController : ControllerBase
    {
        private readonly ARDBContext _context;

        public CustomerDuesController(ARDBContext context)
        {
            _context = context;
        }

        // GET: api/CustomerDues
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerDue>>> GetCustomerDues()
        {
            if (_context.CustomerDues == null)
            {
                return NotFound();
            }
            return await _context.CustomerDues.ToListAsync();
        }

        // GET: api/CustomerDues/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDue>> GetCustomerDue(string id)
        {
            if (_context.CustomerDues == null)
            {
                return NotFound();
            }
            var customerDue = await _context.CustomerDues.FindAsync(id);

            if (customerDue == null)
            {
                return NotFound();
            }

            return customerDue;
        }

        // PUT: api/CustomerDues/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomerDue(string id, CustomerDue customerDue)
        {
            if (id != customerDue.InvoiceNumber)
            {
                return BadRequest();
            }

            _context.Entry(customerDue).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerDueExists(id))
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

        // POST: api/CustomerDues
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CustomerDue>> PostCustomerDue(CustomerDue customerDue)
        {
            if (_context.CustomerDues == null)
            {
                return Problem("Entity set 'ARDBContext.CustomerDues'  is null.");
            }
            _context.CustomerDues.Add(customerDue);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CustomerDueExists(customerDue.InvoiceNumber))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCustomerDue", new { id = customerDue.InvoiceNumber }, customerDue);
        }

        // DELETE: api/CustomerDues/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomerDue(string id)
        {
            if (_context.CustomerDues == null)
            {
                return NotFound();
            }
            var customerDue = await _context.CustomerDues.FindAsync(id);
            if (customerDue == null)
            {
                return NotFound();
            }

            _context.CustomerDues.Remove(customerDue);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CustomerDueExists(string id)
        {
            return (_context.CustomerDues?.Any(e => e.InvoiceNumber == id)).GetValueOrDefault();
        }
    }
}