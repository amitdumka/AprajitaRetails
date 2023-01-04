using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AprajitaRetails.Server.Data;
using AprajitaRetails.Shared.Models.Banking;
using AprajitaRetails.Shared.Models.Payroll;
using AprajitaRetails.Shared.Models.Vouchers;
using AprajitaRetails.Shared.ViewModels;
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
        public async Task<ActionResult<IEnumerable<SelectOption>>> GetLedgerGroups(string storeid)
        {
            if (_context.LedgerGroups == null)
            {
                return NotFound();
            }
            return await _context.LedgerGroups.Select(c => new SelectOption { ID = c.LedgerGroupId, Value = c.GroupName }).ToListAsync();
        }

        [HttpGet("Employees")]
        public async Task<ActionResult<IEnumerable<SelectOption>>> GetEmployees(string storeid)
        {
            if (_context.Employees == null)
            {
                return NotFound();
            }
            return await _context.Employees.Where(c => c.StoreId == storeid && c.IsWorking && !c.MarkedDeleted).Select(c => new SelectOption { ID = c.EmployeeId, Value = c.StaffName }).ToListAsync();
        }

        [HttpGet("Parties")]
        public async Task<ActionResult<IEnumerable<SelectOption>>> GetParties(string storeid)
        {
            if (_context.Parties == null)
            {
                return NotFound();
            }
            return await _context.Parties.Where(c => c.StoreId == storeid && !c.MarkedDeleted).Select(c => new SelectOption { ID = c.PartyId, Value = c.PartyName }).ToListAsync();
        }
        [HttpGet("BankAccounts")]
        public async Task<ActionResult<IEnumerable<SelectOption>>> GetBankAccounts(string storeid)
        {
            if (_context.BankAccounts == null)
            {
                return NotFound();
            }
            return await _context.BankAccounts.Where(c => c.StoreId == storeid && !c.MarkedDeleted).Select(c => new SelectOption { ID = c.BankId, Value = c.AccountHolderName + ", Acc: " + c.AccountNumber }).ToListAsync();
        }
        [HttpGet("Stores")]
        public async Task<ActionResult<IEnumerable<SelectOption>>> GetStores(string storeid)
        {
            if (_context.Stores == null)
            {
                return NotFound();
            }
            return await _context.Stores.Where(c =>  !c.MarkedDeleted).Select(c => new SelectOption { ID = c.StoreId, Value = c.StoreName + ", #: " + c.City }).ToListAsync();
        }
    }
}

