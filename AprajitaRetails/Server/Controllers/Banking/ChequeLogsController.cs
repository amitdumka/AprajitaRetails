using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AprajitaRetails.Server.Data;
using AprajitaRetails.Shared.Models.Banking;

namespace AprajitaRetails.Server.Controllers.Banking
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChequeLogsController : ControllerBase
    {
        private readonly ARDBContext _context;

        public ChequeLogsController(ARDBContext context)
        {
            _context = context;
        }

        // GET: api/ChequeLogs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChequeLog>>> GetChequeLogs()
        {
          if (_context.ChequeLogs == null)
          {
              return NotFound();
          }
            return await _context.ChequeLogs.ToListAsync();
        }

        // GET: api/ChequeLogs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ChequeLog>> GetChequeLog(string id)
        {
          if (_context.ChequeLogs == null)
          {
              return NotFound();
          }
            var chequeLog = await _context.ChequeLogs.FindAsync(id);

            if (chequeLog == null)
            {
                return NotFound();
            }

            return chequeLog;
        }

        // PUT: api/ChequeLogs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChequeLog(string id, ChequeLog chequeLog)
        {
            if (id != chequeLog.ChequeLogId)
            {
                return BadRequest();
            }

            _context.Entry(chequeLog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChequeLogExists(id))
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

        // POST: api/ChequeLogs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ChequeLog>> PostChequeLog(ChequeLog chequeLog)
        {
          if (_context.ChequeLogs == null)
          {
              return Problem("Entity set 'ARDBContext.ChequeLogs'  is null.");
          }
            _context.ChequeLogs.Add(chequeLog);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ChequeLogExists(chequeLog.ChequeLogId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetChequeLog", new { id = chequeLog.ChequeLogId }, chequeLog);
        }

        // DELETE: api/ChequeLogs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChequeLog(string id)
        {
            if (_context.ChequeLogs == null)
            {
                return NotFound();
            }
            var chequeLog = await _context.ChequeLogs.FindAsync(id);
            if (chequeLog == null)
            {
                return NotFound();
            }

            _context.ChequeLogs.Remove(chequeLog);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ChequeLogExists(string id)
        {
            return (_context.ChequeLogs?.Any(e => e.ChequeLogId == id)).GetValueOrDefault();
        }
    }
}
