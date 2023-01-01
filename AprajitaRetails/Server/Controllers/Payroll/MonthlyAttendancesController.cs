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
    [Route("api/[controller]")]
    [ApiController]
    public class MonthlyAttendancesController : ControllerBase
    {
        private readonly ARDBContext _context;

        public MonthlyAttendancesController(ARDBContext context)
        {
            _context = context;
        }

        // GET: api/MonthlyAttendances
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MonthlyAttendance>>> GetMonthlyAttendance()
        {
          if (_context.MonthlyAttendance == null)
          {
              return NotFound();
          }
            return await _context.MonthlyAttendance.ToListAsync();
        }

        // GET: api/MonthlyAttendances/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MonthlyAttendance>> GetMonthlyAttendance(string id)
        {
          if (_context.MonthlyAttendance == null)
          {
              return NotFound();
          }
            var monthlyAttendance = await _context.MonthlyAttendance.FindAsync(id);

            if (monthlyAttendance == null)
            {
                return NotFound();
            }

            return monthlyAttendance;
        }

        // PUT: api/MonthlyAttendances/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMonthlyAttendance(string id, MonthlyAttendance monthlyAttendance)
        {
            if (id != monthlyAttendance.MonthlyAttendanceId)
            {
                return BadRequest();
            }

            _context.Entry(monthlyAttendance).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MonthlyAttendanceExists(id))
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

        // POST: api/MonthlyAttendances
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MonthlyAttendance>> PostMonthlyAttendance(MonthlyAttendance monthlyAttendance)
        {
          if (_context.MonthlyAttendance == null)
          {
              return Problem("Entity set 'ARDBContext.MonthlyAttendance'  is null.");
          }
            _context.MonthlyAttendance.Add(monthlyAttendance);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MonthlyAttendanceExists(monthlyAttendance.MonthlyAttendanceId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMonthlyAttendance", new { id = monthlyAttendance.MonthlyAttendanceId }, monthlyAttendance);
        }

        // DELETE: api/MonthlyAttendances/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMonthlyAttendance(string id)
        {
            if (_context.MonthlyAttendance == null)
            {
                return NotFound();
            }
            var monthlyAttendance = await _context.MonthlyAttendance.FindAsync(id);
            if (monthlyAttendance == null)
            {
                return NotFound();
            }

            _context.MonthlyAttendance.Remove(monthlyAttendance);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MonthlyAttendanceExists(string id)
        {
            return (_context.MonthlyAttendance?.Any(e => e.MonthlyAttendanceId == id)).GetValueOrDefault();
        }
    }
}
