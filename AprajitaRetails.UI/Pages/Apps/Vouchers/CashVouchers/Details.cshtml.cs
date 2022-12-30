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
    public class DetailsModel : PageModel
    {
        private readonly AprajitaRetails.UI.Data.ApplicationDbContext _context;

        public DetailsModel(AprajitaRetails.UI.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public CashVoucher CashVoucher { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.CashVouchers == null)
            {
                return NotFound();
            }

            var cashvoucher = await _context.CashVouchers.FirstOrDefaultAsync(m => m.VoucherNumber == id);
            if (cashvoucher == null)
            {
                return NotFound();
            }
            else 
            {
                CashVoucher = cashvoucher;
            }
            return Page();
        }
    }
}
