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
    public class ProductSubCategoriesController : ControllerBase
    {
        private readonly ARDBContext _context;

        public ProductSubCategoriesController(ARDBContext context)
        {
            _context = context;
        }

        // GET: api/ProductSubCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductSubCategory>>> GetProductSubCategories()
        {
          if (_context.ProductSubCategories == null)
          {
              return NotFound();
          }
            return await _context.ProductSubCategories.ToListAsync();
        }

        // GET: api/ProductSubCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductSubCategory>> GetProductSubCategory(string id)
        {
          if (_context.ProductSubCategories == null)
          {
              return NotFound();
          }
            var productSubCategory = await _context.ProductSubCategories.FindAsync(id);

            if (productSubCategory == null)
            {
                return NotFound();
            }

            return productSubCategory;
        }

        // PUT: api/ProductSubCategories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductSubCategory(string id, ProductSubCategory productSubCategory)
        {
            if (id != productSubCategory.SubCategory)
            {
                return BadRequest();
            }

            _context.Entry(productSubCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductSubCategoryExists(id))
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

        // POST: api/ProductSubCategories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductSubCategory>> PostProductSubCategory(ProductSubCategory productSubCategory)
        {
          if (_context.ProductSubCategories == null)
          {
              return Problem("Entity set 'ARDBContext.ProductSubCategories'  is null.");
          }
            _context.ProductSubCategories.Add(productSubCategory);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProductSubCategoryExists(productSubCategory.SubCategory))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProductSubCategory", new { id = productSubCategory.SubCategory }, productSubCategory);
        }

        // DELETE: api/ProductSubCategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductSubCategory(string id)
        {
            if (_context.ProductSubCategories == null)
            {
                return NotFound();
            }
            var productSubCategory = await _context.ProductSubCategories.FindAsync(id);
            if (productSubCategory == null)
            {
                return NotFound();
            }

            _context.ProductSubCategories.Remove(productSubCategory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductSubCategoryExists(string id)
        {
            return (_context.ProductSubCategories?.Any(e => e.SubCategory == id)).GetValueOrDefault();
        }
    }
}
