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
    public class IndexModel : PageModel
    {
        private readonly AprajitaRetails.UI.Data.ApplicationDbContext _context;

        public IndexModel(AprajitaRetails.UI.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<PettyCashSheet> PettyCashSheet { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.PettyCashSheets != null)
            {
                PettyCashSheet = await _context.PettyCashSheets.ToListAsync();
            }
        }
    }
}
