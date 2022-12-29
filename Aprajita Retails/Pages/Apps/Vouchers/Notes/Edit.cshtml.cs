using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AprajitaRetails.Shared.Models.Models.Vouchers;
using Aprajita_Retails.Data;

namespace Aprajita_Retails.Pages.Apps.Vouchers.Notes
{
    public class EditModel : PageModel
    {
        private readonly Aprajita_Retails.Data.ApplicationDbContext _context;

        public EditModel(Aprajita_Retails.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Note Note { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.Notes == null)
            {
                return NotFound();
            }

            var note =  await _context.Notes.FirstOrDefaultAsync(m => m.NoteNumber == id);
            if (note == null)
            {
                return NotFound();
            }
            Note = note;
           ViewData["PartyId"] = new SelectList(_context.Parties, "PartyId", "PartyId");
           ViewData["StoreId"] = new SelectList(_context.Stores, "StoreId", "StoreId");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Note).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NoteExists(Note.NoteNumber))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool NoteExists(string id)
        {
          return _context.Notes.Any(e => e.NoteNumber == id);
        }
    }
}
