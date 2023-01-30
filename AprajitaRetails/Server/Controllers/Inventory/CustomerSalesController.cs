using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AprajitaRetails.Server.Data;
using AprajitaRetails.Shared.Models.Inventory;

namespace AprajitaRetails.Server.Controllers.Inventory
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerSalesController : ControllerBase
    {
        private readonly ARDBContext _context;

        public CustomerSalesController(ARDBContext context)
        {
            _context = context;
        }

        // GET: api/CustomerSales
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerSale>>> GetCustomerSales()
        {
          if (_context.CustomerSales == null)
          {
              return NotFound();
          }
            return await _context.CustomerSales.ToListAsync();
        }

        // GET: api/CustomerSales/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerSale>> GetCustomerSale(string id)
        {
          if (_context.CustomerSales == null)
          {
              return NotFound();
          }
            var customerSale = await _context.CustomerSales.FindAsync(id);

            if (customerSale == null)
            {
                return NotFound();
            }

            return customerSale;
        }

        // PUT: api/CustomerSales/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomerSale(string id, CustomerSale customerSale)
        {
            if (id != customerSale.InvoiceNumber)
            {
                return BadRequest();
            }

            _context.Entry(customerSale).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerSaleExists(id))
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

        // POST: api/CustomerSales
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CustomerSale>> PostCustomerSale(CustomerSale customerSale)
        {
          if (_context.CustomerSales == null)
          {
              return Problem("Entity set 'ARDBContext.CustomerSales'  is null.");
          }
            _context.CustomerSales.Add(customerSale);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CustomerSaleExists(customerSale.InvoiceNumber))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCustomerSale", new { id = customerSale.InvoiceNumber }, customerSale);
        }

        // DELETE: api/CustomerSales/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomerSale(string id)
        {
            if (_context.CustomerSales == null)
            {
                return NotFound();
            }
            var customerSale = await _context.CustomerSales.FindAsync(id);
            if (customerSale == null)
            {
                return NotFound();
            }

            _context.CustomerSales.Remove(customerSale);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CustomerSaleExists(string id)
        {
            return (_context.CustomerSales?.Any(e => e.InvoiceNumber == id)).GetValueOrDefault();
        }
    }
}
