using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AprajitaRetails.Shared.Models.Models.Vouchers;
using AprajitaRetails.UI.Data;

namespace AprajitaRetails.UI.Pages.Apps.Vouchers.CashVouchers
{
    public class IndexModel : PageModel
    {
        private readonly AprajitaRetails.UI.Data.ApplicationDbContext _context;

        public IndexModel(AprajitaRetails.UI.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<CashVoucher> CashVoucher { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.CashVouchers != null)
            {
                CashVoucher = await _context.CashVouchers
                .Include(c => c.Employee)
                .Include(c => c.Partys)
                .Include(c => c.Store)
                .Include(c => c.TranscationMode).ToListAsync();
            }
        }
    }
}
