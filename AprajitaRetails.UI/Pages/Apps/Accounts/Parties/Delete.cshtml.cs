using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AprajitaRetails.Shared.Models.Models.Vouchers;
using AprajitaRetails.UI.Data;

namespace AprajitaRetails.UI.Pages.Apps.Accounts.Parties
{
    public class DeleteModel : PageModel
    {
        private readonly AprajitaRetails.UI.Data.ApplicationDbContext _context;

        public DeleteModel(AprajitaRetails.UI.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Party Party { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.Parties == null)
            {
                return NotFound();
            }

            var party = await _context.Parties.FirstOrDefaultAsync(m => m.PartyId == id);

            if (party == null)
            {
                return NotFound();
            }
            else 
            {
                Party = party;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null || _context.Parties == null)
            {
                return NotFound();
            }
            var party = await _context.Parties.FindAsync(id);

            if (party != null)
            {
                Party = party;
                _context.Parties.Remove(Party);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
