using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AprajitaRetails.Server.Data;
using AprajitaRetails.Shared.Models.Payroll;
using AprajitaRetails.Shared.Models.Vouchers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AprajitaRetails.Server.Controllers.Helpers
{
    [Route("[controller]")]
    [ApiController]
    public class HelperController : ControllerBase
    {
        private readonly ARDBContext _context;

        public HelperController(ARDBContext context)
        {
            _context = context;
        }

        [HttpGet("LedgerGroups")]
        public async Task<ActionResult<IEnumerable<LedgerGroup>>> GetLedgerGroups()
        {
            if (_context.LedgerGroups == null)
            {
                return NotFound();
            }
            return await _context.LedgerGroups.ToListAsync();
        }
        [HttpGet("Employees")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            if (_context.LedgerGroups == null)
            {
                return NotFound();
            }
            return await _context.Employees.ToListAsync();
        }
        [HttpGet("Parties")]
        public async Task<ActionResult<IEnumerable<Party>>> GetParties()
        {
            if (_context.LedgerGroups == null)
            {
                return NotFound();
            }
            return await _context.Parties.ToListAsync();
        }
        [HttpGet("BankAccounts")]
        public async Task<ActionResult<IEnumerable<BankAccount>>> GetBankAccounts()
        {
            if (_context.LedgerGroups == null)
            {
                return NotFound();
            }
            return await _context.LedgerGroups.ToListAsync();
        }
    }
}

