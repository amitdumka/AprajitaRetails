using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AprajitaRetails.Shared.Models.Models.Stores;
using Aprajita_Retails.Data;

namespace Aprajita_Retails.Pages.Apps
{
    public class StoresModel : PageModel
    {
        private readonly Aprajita_Retails.Data.ApplicationDbContext _context;

        public StoresModel(Aprajita_Retails.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Store> Store { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Stores != null)
            {
                Store = await _context.Stores.ToListAsync();
            }
        }
    }
}
