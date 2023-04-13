﻿using System;
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
using AprajitaRetails.Shared.ViewModels;

namespace AprajitaRetails.Server.Controllers.Inventory
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductSalesController : ControllerBase
    {
        private readonly ARDBContext _context;
        private readonly IMapper _mapper;
        public ProductSalesController(ARDBContext context, IMapper mapper)
        {
            _context = context; _mapper = mapper;
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
        [HttpGet("YearList")]
        public async Task<ActionResult<IEnumerable<int>>> GetProductSales(string storeid)
        {
            if (_context.ProductSales == null)
            {
                return NotFound();
            }
            return await _context.ProductSales.Where(c=>c.StoreId==storeid).Select(c=>c.OnDate.Year).Distinct().OrderBy(c=>c).ToListAsync();
        }

        [HttpGet("ByStore")]
        public async Task<ActionResult<IEnumerable<ProductSale>>> GetProductSalesByStore(string storeid, InvoiceType itpe = InvoiceType.Sales)
        {
            if (_context.ProductSales == null)
            {
                return NotFound();
            }
            return await _context.ProductSales.Include(c => c.Salesman)
                .Where(c => c.StoreId == storeid && c.InvoiceType == itpe && c.OnDate.Year >= DateTime.Today.Year - 1)
                .OrderByDescending(c => c.OnDate)
               .ToListAsync();
        }

        [HttpGet("ByStoreDTO")]
        public async Task<ActionResult<IEnumerable<ProductSaleDTO>>> GetProductSalesByStoreDTO(string storeid, InvoiceType itpe = InvoiceType.Sales)
        {
            if (_context.ProductSales == null)
            {
                return NotFound();
            }
            return await _context.ProductSales.Include(c => c.Salesman).Include(c => c.Store)
                .Where(c => c.StoreId == storeid && c.OnDate.Year >= DateTime.Today.Year && c.InvoiceType == itpe)
                .OrderByDescending(c => c.OnDate).ProjectTo<ProductSaleDTO>(_mapper.ConfigurationProvider)
               .ToListAsync();
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

        [HttpGet("SaleDetails")]
        public async Task<ActionResult<SaleDetailsDTO>> GetProductSaleDetails(string id)
        {
            if (_context.ProductSales == null)
            {
                return NotFound();
            }

            SaleDetailsDTO dto = new SaleDetailsDTO();
           
           var inv= await _context.ProductSales.Include(c => c.Salesman).Include(c => c.Store)
                .Where(c =>c.InvoiceNo==id).ProjectTo<ProductSaleDTO>(_mapper.ConfigurationProvider)
               .FirstOrDefaultAsync();

            if (inv == null) return NotFound();
            else
            {
                dto.Invoice = inv;

                dto.Items= await _context.SaleItems.Include(c => c.ProductItem)
                .Where(c => c.InvoiceNumber == id).ProjectTo<SaleItemDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();

                dto.PaymentDetail = await _context.SalePaymentDetails.Where(c => c.InvoiceNumber == id).FirstOrDefaultAsync();

                if (dto.PaymentDetail.PayMode == PayMode.Card)
                {
                    dto.CardPayment = await _context.CardPaymentDetails.Where(c=>c.InvoiceNumber==id)
                        .ProjectTo<CardPaymentDetailDTO>(_mapper.ConfigurationProvider)
                        .FirstOrDefaultAsync(); 
                }

            }
            return dto;
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
