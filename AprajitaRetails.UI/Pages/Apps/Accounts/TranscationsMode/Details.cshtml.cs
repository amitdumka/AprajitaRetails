using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AprajitaRetails.Shared.Models.Models.Vouchers;
using AprajitaRetails.UI.Data;

namespace AprajitaRetails.UI.Pages.Apps.Accounts.TranscationsMode
{
    public class DetailsModel : PageModel
    {
        private readonly AprajitaRetails.UI.Data.ApplicationDbContext _context;

        public DetailsModel(AprajitaRetails.UI.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public TranscationMode TranscationMode { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.TranscationModes == null)
            {
                return NotFound();
            }

            var transcationmode = await _context.TranscationModes.FirstOrDefaultAsync(m => m.TranscationId == id);
            if (transcationmode == null)
            {
                return NotFound();
            }
            else 
            {
                TranscationMode = transcationmode;
            }
            return Page();
        }
    }
}
