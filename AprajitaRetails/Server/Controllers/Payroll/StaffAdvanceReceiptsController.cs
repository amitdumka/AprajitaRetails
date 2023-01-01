using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AprajitaRetails.Server.Data;
using AprajitaRetails.Shared.Models.Payroll;

namespace AprajitaRetails.Server.Controllers.Payroll
{
    [Route("[controller]")]
    [ApiController]
    public class StaffAdvanceReceiptsController : ControllerBase
    {
        private readonly ARDBContext _context;

        public StaffAdvanceReceiptsController(ARDBContext context)
        {
            _context = context;
        }

        // GET: api/StaffAdvanceReceipts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StaffAdvanceReceipt>>> GetStaffAdvanceReceipt()
        {
          if (_context.StaffAdvanceReceipt == null)
          {
              return NotFound();
          }
            return await _context.StaffAdvanceReceipt.ToListAsync();
        }

        // GET: api/StaffAdvanceReceipts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StaffAdvanceReceipt>> GetStaffAdvanceReceipt(string id)
        {
          if (_context.StaffAdvanceReceipt == null)
          {
              return NotFound();
          }
            var staffAdvanceReceipt = await _context.StaffAdvanceReceipt.FindAsync(id);

            if (staffAdvanceReceipt == null)
            {
                return NotFound();
            }

            return staffAdvanceReceipt;
        }

        // PUT: api/StaffAdvanceReceipts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStaffAdvanceReceipt(string id, StaffAdvanceReceipt staffAdvanceReceipt)
        {
            if (id != staffAdvanceReceipt.StaffAdvanceReceiptId)
            {
                return BadRequest();
            }

            _context.Entry(staffAdvanceReceipt).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StaffAdvanceReceiptExists(id))
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

        // POST: api/StaffAdvanceReceipts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StaffAdvanceReceipt>> PostStaffAdvanceReceipt(StaffAdvanceReceipt staffAdvanceReceipt)
        {
          if (_context.StaffAdvanceReceipt == null)
          {
              return Problem("Entity set 'ARDBContext.StaffAdvanceReceipt'  is null.");
          }
            _context.StaffAdvanceReceipt.Add(staffAdvanceReceipt);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (StaffAdvanceReceiptExists(staffAdvanceReceipt.StaffAdvanceReceiptId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetStaffAdvanceReceipt", new { id = staffAdvanceReceipt.StaffAdvanceReceiptId }, staffAdvanceReceipt);
        }

        // DELETE: api/StaffAdvanceReceipts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStaffAdvanceReceipt(string id)
        {
            if (_context.StaffAdvanceReceipt == null)
            {
                return NotFound();
            }
            var staffAdvanceReceipt = await _context.StaffAdvanceReceipt.FindAsync(id);
            if (staffAdvanceReceipt == null)
            {
                return NotFound();
            }

            _context.StaffAdvanceReceipt.Remove(staffAdvanceReceipt);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StaffAdvanceReceiptExists(string id)
        {
            return (_context.StaffAdvanceReceipt?.Any(e => e.StaffAdvanceReceiptId == id)).GetValueOrDefault();
        }
    }
}
