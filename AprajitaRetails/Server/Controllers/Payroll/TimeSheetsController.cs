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
    public class TimeSheetsController : ControllerBase
    {
        private readonly ARDBContext _context;

        public TimeSheetsController(ARDBContext context)
        {
            _context = context;
        }

        // GET: api/TimeSheets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TimeSheet>>> GetTimeSheet()
        {
          if (_context.TimeSheets == null)
          {
              return NotFound();
          }
            return await _context.TimeSheets.ToListAsync();
        }

        // GET: api/TimeSheets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TimeSheet>> GetTimeSheet(string id)
        {
          if (_context.TimeSheets == null)
          {
              return NotFound();
          }
            var timeSheet = await _context.TimeSheets.FindAsync(id);

            if (timeSheet == null)
            {
                return NotFound();
            }

            return timeSheet;
        }

        // PUT: api/TimeSheets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTimeSheet(string id, TimeSheet timeSheet)
        {
            if (id != timeSheet.Id)
            {
                return BadRequest();
            }

            _context.Entry(timeSheet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TimeSheetExists(id))
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

        // POST: api/TimeSheets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TimeSheet>> PostTimeSheet(TimeSheet timeSheet)
        {
          if (_context.TimeSheets == null)
          {
              return Problem("Entity set 'ARDBContext.TimeSheet'  is null.");
          }
            _context.TimeSheets.Add(timeSheet);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TimeSheetExists(timeSheet.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTimeSheet", new { id = timeSheet.Id }, timeSheet);
        }

        // DELETE: api/TimeSheets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTimeSheet(string id)
        {
            if (_context.TimeSheets == null)
            {
                return NotFound();
            }
            var timeSheet = await _context.TimeSheets.FindAsync(id);
            if (timeSheet == null)
            {
                return NotFound();
            }

            _context.TimeSheets.Remove(timeSheet);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TimeSheetExists(string id)
        {
            return (_context.TimeSheets?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
