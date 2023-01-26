using AprajitaRetails.Server.Data;
using AprajitaRetails.Shared.AutoMapper.DTO;
using AprajitaRetails.Shared.Models.Vouchers;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AprajitaRetails.Server.Controllers.Vouchers
{
    [Route("[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly ARDBContext _context;
        private readonly IMapper _mapper;
        public NotesController(ARDBContext context, IMapper mapper)
        {
            _context = context; _mapper = mapper;
        }

        // GET: api/Notes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Note>>> GetNotes()
        {
            if (_context.Notes == null)
            {
                return NotFound();
            }
            return await _context.Notes.OrderByDescending(c => c.OnDate).ToListAsync();
        }

        [HttpGet("ByStore")]
        public async Task<ActionResult<IEnumerable<Note>>> GetNotesByStore(string storeid)
        {
            if (_context.Notes == null)
            {
                return NotFound();
            }
            return await _context.Notes.Where(c => c.StoreId == storeid && c.OnDate.Year > (DateTime.Today.Year - 2)).OrderByDescending(c => c.OnDate).ToListAsync();
        }

        [HttpGet("ByStoreDTO")]
        public async Task<ActionResult<IEnumerable<NoteDTO>>> GetNotesByStoreDTO(string storeid)
        {
            if (_context.Notes == null)
            {
                return NotFound();
            }
            return await _context.Notes.Include(c => c.Store).Include(c => c.Party).Where(c => c.StoreId == storeid && c.OnDate.Year > (DateTime.Today.Year - 2)).OrderByDescending(c => c.OnDate)
                .ProjectTo<NoteDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        // GET: api/Notes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Note>> GetNote(string id)
        {
            if (_context.Notes == null)
            {
                return NotFound();
            }
            var note = await _context.Notes.FindAsync(id);

            if (note == null)
            {
                return NotFound();
            }

            return note;
        }

        // PUT: api/Notes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNote(string id, Note note)
        {
            if (id != note.NoteNumber)
            {
                return BadRequest();
            }

            _context.Entry(note).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NoteExists(id))
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

        // POST: api/Notes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Note>> PostNote(Note note)
        {
            if (_context.Notes == null)
            {
                return Problem("Entity set 'ARDBContext.Notes'  is null.");
            }

            //TODO: Note ID Generantion
            _context.Notes.Add(note);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (NoteExists(note.NoteNumber))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetNote", new { id = note.NoteNumber }, note);
        }

        // DELETE: api/Notes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNote(string id)
        {
            if (_context.Notes == null)
            {
                return NotFound();
            }
            var note = await _context.Notes.FindAsync(id);
            if (note == null)
            {
                return NotFound();
            }

            _context.Notes.Remove(note);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NoteExists(string id)
        {
            return (_context.Notes?.Any(e => e.NoteNumber == id)).GetValueOrDefault();
        }
    }
}