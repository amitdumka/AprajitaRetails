using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AprajitaRetails.Shared.Models.Models.Vouchers;
using AprajitaRetails.UI.Data;

namespace AprajitaRetails.UI.Pages.Apps.Vouchers.CashVouchers
{
    public class CreateModel : PageModel
    {
        private readonly AprajitaRetails.UI.Data.ApplicationDbContext _context;

        public CreateModel(AprajitaRetails.UI.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeId");
        ViewData["PartyId"] = new SelectList(_context.Parties, "PartyId", "PartyId");
        ViewData["StoreId"] = new SelectList(_context.Stores, "StoreId", "StoreId");
        ViewData["TranscationId"] = new SelectList(_context.TranscationModes, "TranscationId", "TranscationId");
            return Page();
        }

        [BindProperty]
        public CashVoucher CashVoucher { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.CashVouchers == null || CashVoucher == null)
            {
                return Page();
            }

            _context.CashVouchers.Add(CashVoucher);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
