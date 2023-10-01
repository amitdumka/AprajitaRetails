using AprajitaRetails.Server.Data;
using AprajitaRetails.Shared.AutoMapper.DTO;
using AprajitaRetails.Shared.Models.Stores;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AprajitaRetails.Server.Controllers.Stores
{
    [Route("api/[controller]")]
    [ApiController]
    public class CashDetailsController : ControllerBase
    {
        private readonly ARDBContext _context;
        private readonly IMapper _mapper;

        public CashDetailsController(ARDBContext context, IMapper mapper)
        {
            _context = context; _mapper = mapper;
        }

        // GET: api/CashDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CashDetail>>> GetCashDetail()
        {
            if (_context.CashDetails == null)
            {
                return NotFound();
            }
            return await _context.CashDetails.ToListAsync();
        }
        [HttpGet("ByStoreDTO")]
        public async Task<ActionResult<IEnumerable<CashDetailDTO>>> GetCashDetailByStoreDTO(string storeid)
        {
            if (_context.CashDetails == null)
            {
                return NotFound();
            }
            return await _context.CashDetails.Include(c=>c.Store).Where(c=>c.StoreId==storeid && !c.MarkedDeleted && c.OnDate.Year>=DateTime.Today.Year-1).ProjectTo<CashDetailDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        // GET: api/CashDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CashDetail>> GetCashDetail(string id)
        {
            if (_context.CashDetails == null)
            {
                return NotFound();
            }
            var cashDetail = await _context.CashDetails.FindAsync(id);

            if (cashDetail == null)
            {
                return NotFound();
            }

            return cashDetail;
        }

        // PUT: api/CashDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCashDetail(string id, CashDetail cashDetail)
        {
            if (id != cashDetail.CashDetailId)
            {
                return BadRequest();
            }

            _context.Entry(cashDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CashDetailExists(id))
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

        // POST: api/CashDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CashDetail>> PostCashDetail(CashDetail cashDetail)
        {
            if (_context.CashDetails == null)
            {
                return Problem("Entity set 'ARDBContext.CashDetail'  is null.");
            }

            //TODO:Cash Detail ID generation
            _context.CashDetails.Add(cashDetail);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CashDetailExists(cashDetail.CashDetailId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCashDetail", new { id = cashDetail.CashDetailId }, cashDetail);
        }

        // DELETE: api/CashDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCashDetail(string id)
        {
            if (_context.CashDetails == null)
            {
                return NotFound();
            }
            var cashDetail = await _context.CashDetails.FindAsync(id);
            if (cashDetail == null)
            {
                return NotFound();
            }

            _context.CashDetails.Remove(cashDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CashDetailExists(string id)
        {
            return (_context.CashDetails?.Any(e => e.CashDetailId == id)).GetValueOrDefault();
        }
    }
}
