using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AprajitaRetails.Shared.Models.Models.Vouchers;
using AprajitaRetails.UI.Data;

namespace AprajitaRetails.UI.Pages.Apps.Accounts.PettyCashSheets
{
    public class DeleteModel : PageModel
    {
        private readonly AprajitaRetails.UI.Data.ApplicationDbContext _context;

        public DeleteModel(AprajitaRetails.UI.Data.ApplicationDbContext context)
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

            var pettycashsheet = await _context.PettyCashSheets.FirstOrDefaultAsync(m => m.Id == id);

            if (pettycashsheet == null)
            {
                return NotFound();
            }
            else 
            {
                PettyCashSheet = pettycashsheet;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null || _context.PettyCashSheets == null)
            {
                return NotFound();
            }
            var pettycashsheet = await _context.PettyCashSheets.FindAsync(id);

            if (pettycashsheet != null)
            {
                PettyCashSheet = pettycashsheet;
                _context.PettyCashSheets.Remove(PettyCashSheet);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
