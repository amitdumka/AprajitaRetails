using AprajitaRetails.Server.BL.Accounts;
using AprajitaRetails.Server.Data;
using AprajitaRetails.Shared.AutoMapper.DTO;
using AprajitaRetails.Shared.Models.Vouchers;
using AprajitaRetails.Shared.ViewModels;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AprajitaRetails.Server.Controllers.Accounts
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartiesController : ControllerBase
    {
        private readonly ARDBContext _context;

        private readonly IMapper _mapper;

        public PartiesController(ARDBContext context, IMapper mapper)
        {
            _context = context; _mapper = mapper;
        }
        [HttpGet("ledgerdetails")]
        public async Task<ActionResult<IEnumerable<LedgerDetail>?>> GetPartryDetais(string storeid, string ledgerid)
        {
            if (_context.Parties == null)
            {
                return NotFound();
            }
            var data = LedgerHelper.GetLedgerDetails(_context, "TAS", storeid, ledgerid);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
            // return await _context.Parties.ToListAsync();
        }


        // GET: api/Parties
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Party>>> GetParties()
        {
            if (_context.Parties == null)
            {
                return NotFound();
            }
            return await _context.Parties.ToListAsync();
        }
        [HttpGet("ByStoreDTO")]
        public async Task<ActionResult<IEnumerable<PartyDTO>>> GetParties(string storeid)
        {
            if (_context.Parties == null)
            {
                return NotFound();
            }
            return await _context.Parties.Include(c => c.LedgerGroup).Where(c => c.StoreId == storeid && !c.MarkedDeleted)
                .ProjectTo<PartyDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        // GET: api/Parties/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Party>> GetParty(string id)
        {
            if (_context.Parties == null)
            {
                return NotFound();
            }
            var party = await _context.Parties.FindAsync(id);

            if (party == null)
            {
                return NotFound();
            }

            return party;
        }

        // PUT: api/Parties/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParty(string id, Party party)
        {
            if (id != party.PartyId)
            {
                return BadRequest();
            }

            _context.Entry(party).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PartyExists(id))
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

        // POST: api/Parties
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Party>> PostParty(Party party)
        {
            if (_context.Parties == null)
            {
                return Problem("Entity set 'ARDBContext.Parties'  is null.");
            }
            _context.Parties.Add(party);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PartyExists(party.PartyId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetParty", new { id = party.PartyId }, party);
        }

        // DELETE: api/Parties/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParty(string id)
        {
            if (_context.Parties == null)
            {
                return NotFound();
            }
            var party = await _context.Parties.FindAsync(id);
            if (party == null)
            {
                return NotFound();
            }

            _context.Parties.Remove(party);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PartyExists(string id)
        {
            return (_context.Parties?.Any(e => e.PartyId == id)).GetValueOrDefault();
        }
    }
}
