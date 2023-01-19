﻿using AprajitaRetails.Server.Data;
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

        [HttpGet("Transactions")]
        public async Task<ActionResult<IEnumerable<SelectOption>>> GetTransactionModes()
        {
            if (_context.TransactionModes == null)
            {
                return NotFound();
            }
            return await _context.TransactionModes.Select(c => new SelectOption { ID = c.TransactionId, Value = c.TransactionName }).ToListAsync();
        }

        [HttpGet("Employees")]
        public async Task<ActionResult<IEnumerable<SelectOption>>> GetEmployees(string storeid)
        {
            if (_context.Employees == null)
            {
                return NotFound();
            }
            if (storeid == "all" || storeid == "ALL")
            {
                return await _context.Employees.Where(c => c.IsWorking && !c.MarkedDeleted).Select(c => new SelectOption { ID = c.EmployeeId, Value = c.StaffName }).ToListAsync();
            }
            return await _context.Employees.Where(c => c.StoreId == storeid && c.IsWorking && !c.MarkedDeleted).Select(c => new SelectOption { ID = c.EmployeeId, Value = c.StaffName }).ToListAsync();
        }

        [HttpGet("Salesman")]
        public async Task<ActionResult<IEnumerable<SelectOption>>> GetSalesman(string storeid)
        {
            if (_context.Salesmen == null)
            {
                return NotFound();
            }
            if (storeid == "all" || storeid == "ALL")
            {
                return await _context.Salesmen.Where(c => c.IsActive && !c.MarkedDeleted).Select(c => new SelectOption { ID = c.SalesmanId, Value = c.Name }).ToListAsync();
            }
            return await _context.Salesmen.Where(c => c.StoreId == storeid && c.IsActive).Select(c => new SelectOption { ID = c.SalesmanId, Value = c.Name }).ToListAsync();
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
            return await _context.BankAccounts.Where(c => c.StoreId == storeid && !c.MarkedDeleted).Select(c => new SelectOption { ID = c.AccountNumber, Value = c.AccountNumber + ", #: " + c.BranchName }).ToListAsync();
        }

        [HttpGet("Stores")]
        public async Task<ActionResult<IEnumerable<SelectOption>>> GetStores()
        {
            if (_context.Stores == null)
            {
                return NotFound();
            }
            return await _context.Stores.Select(c => new SelectOption { ID = c.StoreId, Value = c.StoreName + ", #: " + c.City }).ToListAsync();
        }
    }
}