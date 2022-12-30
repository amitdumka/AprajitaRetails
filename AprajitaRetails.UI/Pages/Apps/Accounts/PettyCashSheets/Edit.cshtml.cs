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

namespace AprajitaRetails.UI.Pages.Apps.Accounts.PettyCashSheets
{
    public class EditModel : PageModel
    {
        private readonly AprajitaRetails.UI.Data.ApplicationDbContext _context;

        public EditModel(AprajitaRetails.UI.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PettyCashSheet PettyCashSheet { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.PettyCashSheets == null)
            {
                return NotFound();
            }

            var pettycashsheet =  await _context.PettyCashSheets.FirstOrDefaultAsync(m => m.Id == id);
            if (pettycashsheet == null)
            {
                return NotFound();
            }
            PettyCashSheet = pettycashsheet;
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

            _context.Attach(PettyCashSheet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PettyCashSheetExists(PettyCashSheet.Id))
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

        private bool PettyCashSheetExists(string id)
        {
          return (_context.PettyCashSheets?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
