using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AprajitaRetails.Server.Data;
using AprajitaRetails.Shared.Models.Banking;
using AutoMapper;

namespace AprajitaRetails.Server.Controllers.Banking
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChequeIssuedsController : ControllerBase
    {
        private readonly ARDBContext _context;
        private readonly IMapper _mapper;
        public ChequeIssuedsController(ARDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/ChequeIssueds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChequeIssued>>> GetChequeIssued()
        {
          if (_context.ChequeIssued == null)
          {
              return NotFound();
          }
            return await _context.ChequeIssued.ToListAsync();
        }
        [HttpGet("ByStore")]
        public async Task<ActionResult<IEnumerable<ChequeIssued>>> GetChequeIssuedByStore(string storeid)
        {
            if (_context.ChequeIssued == null)
            {
                return NotFound();
            }
            return await _context.ChequeIssued.Include(c => c.Store).Include(c => c.BankAccount).Include(c => c.BankAccount.Bank).Where(c => c.StoreId == storeid).OrderByDescending(c => c.OnDate)
                // .ProjectTo<DailySaleDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }
        // GET: api/ChequeIssueds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ChequeIssued>> GetChequeIssued(string id)
        {
          if (_context.ChequeIssued == null)
          {
              return NotFound();
          }
            var chequeIssued = await _context.ChequeIssued.FindAsync(id);

            if (chequeIssued == null)
            {
                return NotFound();
            }

            return chequeIssued;
        }

        // PUT: api/ChequeIssueds/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChequeIssued(string id, ChequeIssued chequeIssued)
        {
            if (id != chequeIssued.ChequeIssuedId)
            {
                return BadRequest();
            }

            _context.Entry(chequeIssued).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChequeIssuedExists(id))
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

        // POST: api/ChequeIssueds
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ChequeIssued>> PostChequeIssued(ChequeIssued chequeIssued)
        {
          if (_context.ChequeIssued == null)
          {
              return Problem("Entity set 'ARDBContext.ChequeIssued'  is null.");
          }
            _context.ChequeIssued.Add(chequeIssued);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ChequeIssuedExists(chequeIssued.ChequeIssuedId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetChequeIssued", new { id = chequeIssued.ChequeIssuedId }, chequeIssued);
        }

        // DELETE: api/ChequeIssueds/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChequeIssued(string id)
        {
            if (_context.ChequeIssued == null)
            {
                return NotFound();
            }
            var chequeIssued = await _context.ChequeIssued.FindAsync(id);
            if (chequeIssued == null)
            {
                return NotFound();
            }

            _context.ChequeIssued.Remove(chequeIssued);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ChequeIssuedExists(string id)
        {
            return (_context.ChequeIssued?.Any(e => e.ChequeIssuedId == id)).GetValueOrDefault();
        }
    }
}
