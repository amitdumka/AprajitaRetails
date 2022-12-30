using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AprajitaRetails.Shared.Models.Models.Vouchers;
using AprajitaRetails.UI.Data;

namespace AprajitaRetails.UI.Pages.Apps.Accounts.TranscationsMode
{
    public class EditModel : PageModel
    {
        private readonly AprajitaRetails.UI.Data.ApplicationDbContext _context;

        public EditModel(AprajitaRetails.UI.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TranscationMode TranscationMode { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.TranscationModes == null)
            {
                return NotFound();
            }

            var transcationmode =  await _context.TranscationModes.FirstOrDefaultAsync(m => m.TranscationId == id);
            if (transcationmode == null)
            {
                return NotFound();
            }
            TranscationMode = transcationmode;
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

            _context.Attach(TranscationMode).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TranscationModeExists(TranscationMode.TranscationId))
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

        private bool TranscationModeExists(string id)
        {
          return (_context.TranscationModes?.Any(e => e.TranscationId == id)).GetValueOrDefault();
        }
    }
}
