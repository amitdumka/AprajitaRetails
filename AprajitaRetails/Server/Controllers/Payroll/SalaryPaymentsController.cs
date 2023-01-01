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
    public class SalaryPaymentsController : ControllerBase
    {
        private readonly ARDBContext _context;

        public SalaryPaymentsController(ARDBContext context)
        {
            _context = context;
        }

        // GET: api/SalaryPayments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SalaryPayment>>> GetSalaryPayment()
        {
          if (_context.SalaryPayment == null)
          {
              return NotFound();
          }
            return await _context.SalaryPayment.ToListAsync();
        }

        // GET: api/SalaryPayments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SalaryPayment>> GetSalaryPayment(string id)
        {
          if (_context.SalaryPayment == null)
          {
              return NotFound();
          }
            var salaryPayment = await _context.SalaryPayment.FindAsync(id);

            if (salaryPayment == null)
            {
                return NotFound();
            }

            return salaryPayment;
        }

        // PUT: api/SalaryPayments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSalaryPayment(string id, SalaryPayment salaryPayment)
        {
            if (id != salaryPayment.SalaryPaymentId)
            {
                return BadRequest();
            }

            _context.Entry(salaryPayment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalaryPaymentExists(id))
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

        // POST: api/SalaryPayments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SalaryPayment>> PostSalaryPayment(SalaryPayment salaryPayment)
        {
          if (_context.SalaryPayment == null)
          {
              return Problem("Entity set 'ARDBContext.SalaryPayment'  is null.");
          }
            _context.SalaryPayment.Add(salaryPayment);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SalaryPaymentExists(salaryPayment.SalaryPaymentId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSalaryPayment", new { id = salaryPayment.SalaryPaymentId }, salaryPayment);
        }

        // DELETE: api/SalaryPayments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSalaryPayment(string id)
        {
            if (_context.SalaryPayment == null)
            {
                return NotFound();
            }
            var salaryPayment = await _context.SalaryPayment.FindAsync(id);
            if (salaryPayment == null)
            {
                return NotFound();
            }

            _context.SalaryPayment.Remove(salaryPayment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SalaryPaymentExists(string id)
        {
            return (_context.SalaryPayment?.Any(e => e.SalaryPaymentId == id)).GetValueOrDefault();
        }
    }
}
