using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AprajitaRetails.Server.Data;
using AprajitaRetails.Shared.Models.Inventory;
using AprajitaRetails.Shared.AutoMapper.DTO;

namespace AprajitaRetails.Server.Controllers.Inventory
{
    [Route("api/[controller]")]
    [ApiController]
    public class StocksController : ControllerBase
    {
        private readonly ARDBContext _context;

        public StocksController(ARDBContext context)
        {
            _context = context;
        }

        // GET: api/Stocks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Stock>>> GetStocks()
        {
            if (_context.Stocks == null)
            {
                return NotFound();
            }
            return await _context.Stocks.ToListAsync();
        }

        [HttpGet("ByBarcode")]
        public async Task<ActionResult<IEnumerable<StockViewModel>>> GetBarcode(string barcode, string storeid)
        {
            if (_context.Stocks == null)
            {
                return NotFound();
            }
            return await _context.Stocks
                     .Include(c => c.Product)
                     .Where(c => c.Barcode == barcode && c.StoreId == storeid)
                     .Select(c => new StockViewModel
                     {
                         Barcode = c.Barcode,
                         CurrentQty = c.CurrentQty,
                         HoldQty = c.CurrentQtyWH,
                         Id = c.Id,
                         Rate = c.MRP,
                         MutliPrice = c.MultiPrice,
                         Unit = c.Unit,
                         ProductName = c.Product.Name,
                         TaxRate = c.Product.TaxType,
                         HSNCode = c.Product.HSNCode
                     })
                     .ToListAsync();
        }

        // GET: api/Stocks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Stock>> GetStock(Guid id)
        {
            if (_context.Stocks == null)
            {
                return NotFound();
            }
            var stock = await _context.Stocks.FindAsync(id);

            if (stock == null)
            {
                return NotFound();
            }

            return stock;
        }

        // PUT: api/Stocks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStock(Guid id, Stock stock)
        {
            if (id != stock.Id)
            {
                return BadRequest();
            }

            _context.Entry(stock).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StockExists(id))
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

        // POST: api/Stocks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Stock>> PostStock(Stock stock)
        {
            if (_context.Stocks == null)
            {
                return Problem("Entity set 'ARDBContext.Stocks'  is null.");
            }
            _context.Stocks.Add(stock);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStock", new { id = stock.Id }, stock);
        }

        // DELETE: api/Stocks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStock(Guid id)
        {
            if (_context.Stocks == null)
            {
                return NotFound();
            }
            var stock = await _context.Stocks.FindAsync(id);
            if (stock == null)
            {
                return NotFound();
            }

            _context.Stocks.Remove(stock);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StockExists(Guid id)
        {
            return (_context.Stocks?.Any(e => e.Id == id)).GetValueOrDefault();
        }


    }
}
