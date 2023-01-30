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
    public class PurchaseItemsController : ControllerBase
    {
        private readonly ARDBContext _context;

        public PurchaseItemsController(ARDBContext context)
        {
            _context = context;
        }

        // GET: api/PurchaseItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PurchaseItem>>> GetPurchaseItems()
        {
          if (_context.PurchaseItems == null)
          {
              return NotFound();
          }
            return await _context.PurchaseItems.ToListAsync();
        }

        // GET: api/PurchaseItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PurchaseItem>> GetPurchaseItem(int id)
        {
          if (_context.PurchaseItems == null)
          {
              return NotFound();
          }
            var purchaseItem = await _context.PurchaseItems.FindAsync(id);

            if (purchaseItem == null)
            {
                return NotFound();
            }

            return purchaseItem;
        }

        // PUT: api/PurchaseItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPurchaseItem(int id, PurchaseItem purchaseItem)
        {
            if (id != purchaseItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(purchaseItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PurchaseItemExists(id))
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

        // POST: api/PurchaseItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PurchaseItem>> PostPurchaseItem(PurchaseItem purchaseItem)
        {
          if (_context.PurchaseItems == null)
          {
              return Problem("Entity set 'ARDBContext.PurchaseItems'  is null.");
          }
            _context.PurchaseItems.Add(purchaseItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPurchaseItem", new { id = purchaseItem.Id }, purchaseItem);
        }

        // DELETE: api/PurchaseItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePurchaseItem(int id)
        {
            if (_context.PurchaseItems == null)
            {
                return NotFound();
            }
            var purchaseItem = await _context.PurchaseItems.FindAsync(id);
            if (purchaseItem == null)
            {
                return NotFound();
            }

            _context.PurchaseItems.Remove(purchaseItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PurchaseItemExists(int id)
        {
            return (_context.PurchaseItems?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
