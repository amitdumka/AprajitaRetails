using AprajitaRetails.Server.Data;
using AprajitaRetails.Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AprajitaRetails.Server.Controllers.Helpers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelperController : ControllerBase
    {
        private readonly ARDBContext _context;

        public HelperController(ARDBContext context)
        {
            _context = context;
        }

        [HttpGet("StoreGroups")]
        public async Task<ActionResult<IEnumerable<SelectOption>>> GetStoreGroups()
        {
            if (_context.StoreGroups == null)
            {
                return NotFound();
            }
            return await _context.StoreGroups.Include(c=>c.AppClient).Select(c => new SelectOption { ID = c.StoreGroupId, Value = c.GroupName+ $"[ {c.AppClient.ClientName} ]" }).ToListAsync();
        }

        [HttpGet("Clients")]
        public async Task<ActionResult<IEnumerable<SelectOption>>> GetClients()
        {
            if (_context.AppClients == null)
            {
                return NotFound();
            }
            return await _context.AppClients.Select(c => new SelectOption { ID = c.AppClientId.ToString(), Value = c.ClientName }).ToListAsync();
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
            return await _context.Parties.Where(c =>  !c.MarkedDeleted).Select(c => new SelectOption { ID = c.PartyId, Value = c.PartyName }).ToListAsync();
            //return await _context.Parties.Where(c => c.StoreId == storeid && !c.MarkedDeleted).Select(c => new SelectOption { ID = c.PartyId, Value = c.PartyName }).ToListAsync();
        }

        [HttpGet("MPOS")]
        public async Task<ActionResult<IEnumerable<SelectOption>>> GetMPos(string storeid)
        {
            if (_context.EDCTerminals == null)
            {
                return NotFound();
            }
            return await _context.EDCTerminals.Where(c => !c.MarkedDeleted).Select(c => new SelectOption { ID = c.EDCTerminalId, Value = c.Name }).ToListAsync();
           // return await _context.EDCTerminals.Where(c => c.StoreId == storeid && !c.MarkedDeleted).Select(c => new SelectOption { ID = c.EDCTerminalId, Value = c.Name }).ToListAsync();
        }

        [HttpGet("BankAccounts")]
        public async Task<ActionResult<IEnumerable<SelectOption>>> GetBankAccounts(string storeid)
        {
            if (_context.BankAccounts == null)
            {
                return NotFound();
            }
            //TODO: convert all to either storegroup or appclient level
            return await _context.BankAccounts.Where(c =>  !c.MarkedDeleted).Select(c => new SelectOption { ID = c.AccountNumber, Value = c.AccountNumber + ", #: " + c.BranchName }).ToListAsync();
            //return await _context.BankAccounts.Where(c => c.StoreId == storeid && !c.MarkedDeleted).Select(c => new SelectOption { ID = c.AccountNumber, Value = c.AccountNumber + ", #: " + c.BranchName }).ToListAsync();
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
        [HttpGet("Stores{ID}")]
        public async Task<ActionResult<IEnumerable<SelectOption>>> GetStoresByGroups(string storeGroupId)
        {
            if (_context.Stores == null)
            {
                return NotFound();
            }
            return await _context.Stores.Where(c=>c.StoreGroupId==storeGroupId).Select(c => new SelectOption { ID = c.StoreId, Value = c.StoreName + ", #: " + c.City }).ToListAsync();
        }
    }
}