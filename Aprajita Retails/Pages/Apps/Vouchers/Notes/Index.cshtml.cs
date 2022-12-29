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
    public class IndexModel : PageModel
    {
        private readonly Aprajita_Retails.Data.ApplicationDbContext _context;

        public IndexModel(Aprajita_Retails.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Note> Note { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Notes != null)
            {
                Note = await _context.Notes
                .Include(n => n.Party)
                .Include(n => n.Store).ToListAsync();
            }
        }
    }
}
