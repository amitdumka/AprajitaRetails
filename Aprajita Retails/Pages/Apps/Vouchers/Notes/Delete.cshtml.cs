using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AprajitaRetails.Shared.Models.Models.Vouchers;
using Aprajita_Retails.Data;

namespace Aprajita_Retails.Pages.Apps.Vouchers.Notes
{
    public class DeleteModel : PageModel
    {
        private readonly Aprajita_Retails.Data.ApplicationDbContext _context;

        public DeleteModel(Aprajita_Retails.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Note Note { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.Notes == null)
            {
                return NotFound();
            }

            var note = await _context.Notes.FirstOrDefaultAsync(m => m.NoteNumber == id);

            if (note == null)
            {
                return NotFound();
            }
            else 
            {
                Note = note;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null || _context.Notes == null)
            {
                return NotFound();
            }
            var note = await _context.Notes.FindAsync(id);

            if (note != null)
            {
                Note = note;
                _context.Notes.Remove(Note);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}