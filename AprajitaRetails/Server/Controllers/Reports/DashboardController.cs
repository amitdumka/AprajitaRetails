using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AprajitaRetails.Server.Data;
using AprajitaRetails.Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



namespace AprajitaRetails.Server.Controllers.Reports
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {

        private readonly ARDBContext _context;
        public DashboardController(ARDBContext context)
        {
            _context = context;
        }

        [HttpGet("StoreManagerDashboard")]
        public async Task<ActionResult<IEnumerable<SelectOption>>> GetLedgerGroups(string storeid)
        {
            if (_context.LedgerGroups == null)
            {
                return NotFound();
            }
            return await _context.LedgerGroups.Select(c => new SelectOption { ID = c.LedgerGroupId, Value = c.GroupName }).ToListAsync();
        }
    }
}

