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
using AprajitaRetails.Shared.AutoMapper.DTO;
using AutoMapper.QueryableExtensions;

namespace AprajitaRetails.Server.Controllers.Banking
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChequeBooksController : ControllerBase
    {
        private readonly ARDBContext _context;
        private readonly IMapper _mapper;
        public ChequeBooksController(ARDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/ChequeBooks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChequeBook>>> GetChequeBooks()
        {
          if (_context.ChequeBooks == null)
          {
              return NotFound();
          }
            return await _context.ChequeBooks.ToListAsync();
        }
        [HttpGet("ByStore")]
        public async Task<ActionResult<IEnumerable<ChequeBook>>> GetChequeBooksByStore(string storeid)
        {
            if (_context.ChequeBooks == null)
            {
                return NotFound();
            }
            return await _context.ChequeBooks.Include(c => c.Store).Include(c => c.BankAccount).Include(c => c.BankAccount.Bank).Where(c => c.StoreId == storeid ).OrderByDescending(c => c.IssuedDate)
               // .ProjectTo<DailySaleDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }
        // GET: api/ChequeBooks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ChequeBook>> GetChequeBook(string id)
        {
          if (_context.ChequeBooks == null)
          {
              return NotFound();
          }
            var chequeBook = await _context.ChequeBooks.FindAsync(id);

            if (chequeBook == null)
            {
                return NotFound();
            }

            return chequeBook;
        }

        // PUT: api/ChequeBooks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChequeBook(string id, ChequeBook chequeBook)
        {
            if (id != chequeBook.ChequeBookId)
            {
                return BadRequest();
            }

            _context.Entry(chequeBook).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChequeBookExists(id))
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

        // POST: api/ChequeBooks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ChequeBook>> PostChequeBook(ChequeBook chequeBook)
        {
          if (_context.ChequeBooks == null)
          {
              return Problem("Entity set 'ARDBContext.ChequeBooks'  is null.");
          }
            _context.ChequeBooks.Add(chequeBook);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ChequeBookExists(chequeBook.ChequeBookId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetChequeBook", new { id = chequeBook.ChequeBookId }, chequeBook);
        }

        // DELETE: api/ChequeBooks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChequeBook(string id)
        {
            if (_context.ChequeBooks == null)
            {
                return NotFound();
            }
            var chequeBook = await _context.ChequeBooks.FindAsync(id);
            if (chequeBook == null)
            {
                return NotFound();
            }

            _context.ChequeBooks.Remove(chequeBook);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ChequeBookExists(string id)
        {
            return (_context.ChequeBooks?.Any(e => e.ChequeBookId == id)).GetValueOrDefault();
        }
    }
}
