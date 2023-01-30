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
    public class CardPaymentDetailsController : ControllerBase
    {
        private readonly ARDBContext _context;

        public CardPaymentDetailsController(ARDBContext context)
        {
            _context = context;
        }

        // GET: api/CardPaymentDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CardPaymentDetail>>> GetCardPaymentDetails()
        {
          if (_context.CardPaymentDetails == null)
          {
              return NotFound();
          }
            return await _context.CardPaymentDetails.ToListAsync();
        }

        // GET: api/CardPaymentDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CardPaymentDetail>> GetCardPaymentDetail(int id)
        {
          if (_context.CardPaymentDetails == null)
          {
              return NotFound();
          }
            var cardPaymentDetail = await _context.CardPaymentDetails.FindAsync(id);

            if (cardPaymentDetail == null)
            {
                return NotFound();
            }

            return cardPaymentDetail;
        }

        // PUT: api/CardPaymentDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCardPaymentDetail(int id, CardPaymentDetail cardPaymentDetail)
        {
            if (id != cardPaymentDetail.Id)
            {
                return BadRequest();
            }

            _context.Entry(cardPaymentDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CardPaymentDetailExists(id))
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

        // POST: api/CardPaymentDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CardPaymentDetail>> PostCardPaymentDetail(CardPaymentDetail cardPaymentDetail)
        {
          if (_context.CardPaymentDetails == null)
          {
              return Problem("Entity set 'ARDBContext.CardPaymentDetails'  is null.");
          }
            _context.CardPaymentDetails.Add(cardPaymentDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCardPaymentDetail", new { id = cardPaymentDetail.Id }, cardPaymentDetail);
        }

        // DELETE: api/CardPaymentDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCardPaymentDetail(int id)
        {
            if (_context.CardPaymentDetails == null)
            {
                return NotFound();
            }
            var cardPaymentDetail = await _context.CardPaymentDetails.FindAsync(id);
            if (cardPaymentDetail == null)
            {
                return NotFound();
            }

            _context.CardPaymentDetails.Remove(cardPaymentDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CardPaymentDetailExists(int id)
        {
            return (_context.CardPaymentDetails?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
