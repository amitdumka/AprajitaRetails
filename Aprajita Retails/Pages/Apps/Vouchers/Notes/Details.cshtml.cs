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
    public class DetailsModel : PageModel
    {
        private readonly Aprajita_Retails.Data.ApplicationDbContext _context;

        public DetailsModel(Aprajita_Retails.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
