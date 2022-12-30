using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AprajitaRetails.Shared.Models.Models.Vouchers;
using Aprajita_Retails.Data;

namespace Aprajita_Retails.Pages.Apps.Vouchers.CashVouchers
{
    public class DeleteModel : PageModel
    {
        private readonly Aprajita_Retails.Data.ApplicationDbContext _context;

        public DeleteModel(Aprajita_Retails.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public CashVoucher CashVoucher { get; set; }

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

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null || _context.CashVouchers == null)
            {
                return NotFound();
            }
            var cashvoucher = await _context.CashVouchers.FindAsync(id);

            if (cashvoucher != null)
            {
                CashVoucher = cashvoucher;
                _context.CashVouchers.Remove(CashVoucher);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}