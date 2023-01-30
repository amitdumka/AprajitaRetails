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
    public class SalePaymentDetailsController : ControllerBase
    {
        private readonly ARDBContext _context;

        public SalePaymentDetailsController(ARDBContext context)
        {
            _context = context;
        }

        // GET: api/SalePaymentDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SalePaymentDetail>>> GetSalePaymentDetails()
        {
          if (_context.SalePaymentDetails == null)
          {
              return NotFound();
          }
            return await _context.SalePaymentDetails.ToListAsync();
        }

        // GET: api/SalePaymentDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SalePaymentDetail>> GetSalePaymentDetail(int id)
        {
          if (_context.SalePaymentDetails == null)
          {
              return NotFound();
          }
            var salePaymentDetail = await _context.SalePaymentDetails.FindAsync(id);

            if (salePaymentDetail == null)
            {
                return NotFound();
            }

            return salePaymentDetail;
        }

        // PUT: api/SalePaymentDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSalePaymentDetail(int id, SalePaymentDetail salePaymentDetail)
        {
            if (id != salePaymentDetail.Id)
            {
                return BadRequest();
            }

            _context.Entry(salePaymentDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalePaymentDetailExists(id))
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

        // POST: api/SalePaymentDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SalePaymentDetail>> PostSalePaymentDetail(SalePaymentDetail salePaymentDetail)
        {
          if (_context.SalePaymentDetails == null)
          {
              return Problem("Entity set 'ARDBContext.SalePaymentDetails'  is null.");
          }
            _context.SalePaymentDetails.Add(salePaymentDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSalePaymentDetail", new { id = salePaymentDetail.Id }, salePaymentDetail);
        }

        // DELETE: api/SalePaymentDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSalePaymentDetail(int id)
        {
            if (_context.SalePaymentDetails == null)
            {
                return NotFound();
            }
            var salePaymentDetail = await _context.SalePaymentDetails.FindAsync(id);
            if (salePaymentDetail == null)
            {
                return NotFound();
            }

            _context.SalePaymentDetails.Remove(salePaymentDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SalePaymentDetailExists(int id)
        {
            return (_context.SalePaymentDetails?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
