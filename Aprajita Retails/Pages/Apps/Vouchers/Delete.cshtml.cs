using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AprajitaRetails.Shared.Models.Models.Vouchers;
using Aprajita_Retails.Data;

namespace Aprajita_Retails.Pages.Apps.Vouchers
{
    public class DeleteModel : PageModel
    {
        private readonly Aprajita_Retails.Data.ApplicationDbContext _context;

        public DeleteModel(Aprajita_Retails.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Voucher Voucher { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.Vouchers == null)
            {
                return NotFound();
            }

            var voucher = await _context.Vouchers.FirstOrDefaultAsync(m => m.VoucherNumber == id);

            if (voucher == null)
            {
                return NotFound();
            }
            else 
            {
                Voucher = voucher;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null || _context.Vouchers == null)
            {
                return NotFound();
            }
            var voucher = await _context.Vouchers.FindAsync(id);

            if (voucher != null)
            {
                Voucher = voucher;
                _context.Vouchers.Remove(Voucher);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
