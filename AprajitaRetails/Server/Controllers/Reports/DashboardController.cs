using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AprajitaRetails.Server.BL.Dashboard;
using AprajitaRetails.Server.Data;
using AprajitaRetails.Shared.ViewModels;
using AprajitaRetails.Shared.ViewModels.Dashboards;
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
        public async Task<ActionResult<DashboardVM>> GetStoreManagerDashboard(string storeid)
        {
            DashboardWidget widgetwidget = new DashboardWidget();

            return await widgetwidget.GenerateDashboard(storeid,_context);
        }
    }
}

