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
    public class ProductPurchasesController : ControllerBase
    {
        private readonly ARDBContext _context;

        public ProductPurchasesController(ARDBContext context)
        {
            _context = context;
        }

        // GET: api/ProductPurchases
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductPurchase>>> GetProductPurchases()
        {
          if (_context.ProductPurchases == null)
          {
              return NotFound();
          }
            return await _context.ProductPurchases.ToListAsync();
        }

        // GET: api/ProductPurchases/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductPurchase>> GetProductPurchase(string id)
        {
          if (_context.ProductPurchases == null)
          {
              return NotFound();
          }
            var productPurchase = await _context.ProductPurchases.FindAsync(id);

            if (productPurchase == null)
            {
                return NotFound();
            }

            return productPurchase;
        }

        // PUT: api/ProductPurchases/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductPurchase(string id, ProductPurchase productPurchase)
        {
            if (id != productPurchase.InwardNumber)
            {
                return BadRequest();
            }

            _context.Entry(productPurchase).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductPurchaseExists(id))
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

        // POST: api/ProductPurchases
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductPurchase>> PostProductPurchase(ProductPurchase productPurchase)
        {
          if (_context.ProductPurchases == null)
          {
              return Problem("Entity set 'ARDBContext.ProductPurchases'  is null.");
          }
            _context.ProductPurchases.Add(productPurchase);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProductPurchaseExists(productPurchase.InwardNumber))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProductPurchase", new { id = productPurchase.InwardNumber }, productPurchase);
        }

        // DELETE: api/ProductPurchases/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductPurchase(string id)
        {
            if (_context.ProductPurchases == null)
            {
                return NotFound();
            }
            var productPurchase = await _context.ProductPurchases.FindAsync(id);
            if (productPurchase == null)
            {
                return NotFound();
            }

            _context.ProductPurchases.Remove(productPurchase);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductPurchaseExists(string id)
        {
            return (_context.ProductPurchases?.Any(e => e.InwardNumber == id)).GetValueOrDefault();
        }
    }
}
