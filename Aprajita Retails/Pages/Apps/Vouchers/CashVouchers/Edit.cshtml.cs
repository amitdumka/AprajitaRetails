using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AprajitaRetails.Shared.Models.Models.Vouchers;
using Aprajita_Retails.Data;

namespace Aprajita_Retails.Pages.Apps.Vouchers.CashVouchers
{
    public class EditModel : PageModel
    {
        private readonly Aprajita_Retails.Data.ApplicationDbContext _context;

        public EditModel(Aprajita_Retails.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CashVoucher CashVoucher { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.CashVouchers == null)
            {
                return NotFound();
            }

            var cashvoucher =  await _context.CashVouchers.FirstOrDefaultAsync(m => m.CashVoucherNo == id);
            if (cashvoucher == null)
            {
                return NotFound();
            }
            CashVoucher = cashvoucher;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(CashVoucher).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CashVoucherExists(CashVoucher.CashVoucherNo))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CashVoucherExists(string id)
        {
          return _context.CashVouchers.Any(e => e.CashVoucherNo == id);
        }
    }
}
