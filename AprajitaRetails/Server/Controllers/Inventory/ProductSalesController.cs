﻿using System;
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
    public class ProductSalesController : ControllerBase
    {
        private readonly ARDBContext _context;

        public ProductSalesController(ARDBContext context)
        {
            _context = context;
        }

        // GET: api/ProductSales
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductSale>>> GetProductSales()
        {
          if (_context.ProductSales == null)
          {
              return NotFound();
          }
            return await _context.ProductSales.ToListAsync();
        }

        // GET: api/ProductSales/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductSale>> GetProductSale(string id)
        {
          if (_context.ProductSales == null)
          {
              return NotFound();
          }
            var productSale = await _context.ProductSales.FindAsync(id);

            if (productSale == null)
            {
                return NotFound();
            }

            return productSale;
        }

        // PUT: api/ProductSales/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductSale(string id, ProductSale productSale)
        {
            if (id != productSale.InvoiceNo)
            {
                return BadRequest();
            }

            _context.Entry(productSale).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductSaleExists(id))
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

        // POST: api/ProductSales
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductSale>> PostProductSale(ProductSale productSale)
        {
          if (_context.ProductSales == null)
          {
              return Problem("Entity set 'ARDBContext.ProductSales'  is null.");
          }
            _context.ProductSales.Add(productSale);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProductSaleExists(productSale.InvoiceNo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProductSale", new { id = productSale.InvoiceNo }, productSale);
        }

        // DELETE: api/ProductSales/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductSale(string id)
        {
            if (_context.ProductSales == null)
            {
                return NotFound();
            }
            var productSale = await _context.ProductSales.FindAsync(id);
            if (productSale == null)
            {
                return NotFound();
            }

            _context.ProductSales.Remove(productSale);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductSaleExists(string id)
        {
            return (_context.ProductSales?.Any(e => e.InvoiceNo == id)).GetValueOrDefault();
        }
    }
}