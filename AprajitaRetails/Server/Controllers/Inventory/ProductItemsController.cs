using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AprajitaRetails.Server.Data;
using AprajitaRetails.Shared.Models.Inventory;
using AutoMapper;
using AprajitaRetails.Shared.AutoMapper.DTO;
using AutoMapper.QueryableExtensions;

namespace AprajitaRetails.Server.Controllers.Inventory
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductItemsController : ControllerBase
    {
        private readonly ARDBContext _context;
        private readonly IMapper _mapper;
        public ProductItemsController(ARDBContext context, IMapper mapper)
        {
            _context = context; _mapper = mapper;
        }

        // GET: api/ProductItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductItem>>> GetProductItems()
        {
            if (_context.ProductItems == null)
            {
                return NotFound();
            }
            return await _context.ProductItems.ToListAsync();
        }
        [HttpGet("ByStoreDTO")]
        public async Task<ActionResult<IEnumerable<ProductItemDTO>>> GetProductItemsByStoreDTO(string storeid)
        {
            if (_context.ProductItems == null)
            {
                return NotFound();
            }
            if (string.IsNullOrEmpty(storeid))
            {
                var grp = _context.Stores.Find(storeid)?.StoreGroupId;
                if (string.IsNullOrEmpty(grp)) return NotFound();
                return await _context.ProductItems.Include(c => c.Brand).Include(c => c.ProductType).Include(c => c.ProductSubCategory)
                    .Where(c => c.StoreGroupId == grp)
                    .ProjectTo<ProductItemDTO>(_mapper.ConfigurationProvider)
               .ToListAsync();
            }

            return await _context.ProductItems.Include(c => c.Brand).Include(c => c.ProductType).Include(c => c.ProductSubCategory)
                .ProjectTo<ProductItemDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        // GET: api/ProductItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductItem>> GetProductItem(string id)
        {
            if (_context.ProductItems == null)
            {
                return NotFound();
            }
            var productItem = await _context.ProductItems.FindAsync(id);

            if (productItem == null)
            {
                return NotFound();
            }

            return productItem;
        }

        // PUT: api/ProductItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductItem(string id, ProductItem productItem)
        {
            if (id != productItem.Barcode)
            {
                return BadRequest();
            }

            _context.Entry(productItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductItemExists(id))
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

        // POST: api/ProductItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductItem>> PostProductItem(ProductItem productItem)
        {
            if (_context.ProductItems == null)
            {
                return Problem("Entity set 'ARDBContext.ProductItems'  is null.");
            }
            _context.ProductItems.Add(productItem);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProductItemExists(productItem.Barcode))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProductItem", new { id = productItem.Barcode }, productItem);
        }

        // DELETE: api/ProductItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductItem(string id)
        {
            if (_context.ProductItems == null)
            {
                return NotFound();
            }
            var productItem = await _context.ProductItems.FindAsync(id);
            if (productItem == null)
            {
                return NotFound();
            }

            _context.ProductItems.Remove(productItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductItemExists(string id)
        {
            return (_context.ProductItems?.Any(e => e.Barcode == id)).GetValueOrDefault();
        }
    }
}
