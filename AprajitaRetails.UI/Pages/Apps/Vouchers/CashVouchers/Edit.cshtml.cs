using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AprajitaRetails.Shared.Models.Models.Vouchers;
using AprajitaRetails.UI.Data;

namespace AprajitaRetails.UI.Pages.Apps.Vouchers.CashVouchers
{
    public class EditModel : PageModel
    {
        private readonly AprajitaRetails.UI.Data.ApplicationDbContext _context;

        public EditModel(AprajitaRetails.UI.Data.ApplicationDbContext context)
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

            var cashvoucher =  await _context.CashVouchers.FirstOrDefaultAsync(m => m.VoucherNumber == id);
            if (cashvoucher == null)
            {
                return NotFound();
            }
            CashVoucher = cashvoucher;
           ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeId");
           ViewData["PartyId"] = new SelectList(_context.Parties, "PartyId", "PartyId");
           ViewData["StoreId"] = new SelectList(_context.Stores, "StoreId", "StoreId");
           ViewData["TranscationId"] = new SelectList(_context.TranscationModes, "TranscationId", "TranscationId");
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
                if (!CashVoucherExists(CashVoucher.VoucherNumber))
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
          return (_context.CashVouchers?.Any(e => e.VoucherNumber == id)).GetValueOrDefault();
        }
    }
}