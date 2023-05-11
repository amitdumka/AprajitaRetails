using AprajitaRetails.Server.Data;
using AprajitaRetails.Shared.ViewModels.Dashboards;

namespace AprajitaRetails.Server.BL.Dashboard
{
    public class DashboardWidget
    {

        DashboardVM VM;
        
        public async Task< DashboardVM> GenerateDashboard(string storeid, ARDBContext db)
        {
            // Generate Sale Report 
            VM.TodaySale = (decimal)((decimal?) db.ProductSales.Where(c => c.StoreId == storeid && !c.MarkedDeleted && c.OnDate.Date == DateTime.Today.Date)?.Sum(c =>(decimal?) c.TotalPrice) ??0);
            VM.YesterdaySale = ((decimal?)db.ProductSales.Where(c => c.StoreId == storeid && !c.MarkedDeleted && c.OnDate.Date == DateTime.Today.AddDays(-1).Date)?.Select(c=>c.TotalPrice).Sum()) ?? 0;
            VM.YearlySale = ((decimal?)db.ProductSales.Where(c => c.StoreId == storeid && !c.MarkedDeleted && c.OnDate.Date.Year == DateTime.Today.Year)?.Sum(c => c.TotalPrice)) ?? 0;
            VM.MonthlySale = ((decimal?)db.ProductSales.Where(c => c.StoreId == storeid && !c.MarkedDeleted && c.OnDate.Date.Month == DateTime.Today.Month && c.OnDate.Date.Year == DateTime.Today.Year)?.Sum(c => c.TotalPrice)) ?? 0;
            VM.QuarterlySale = ((decimal?)db.ProductSales.Where(c => c.OnDate.Year == DateTime.Today.Year && c.OnDate.Month <= DateTime.Today.Month - 2)?.Sum(c => c.TotalPrice)) ?? 0;
            VM.LastMonthSale = ((decimal?)db.ProductSales.Where(c => c.StoreId == storeid && !c.MarkedDeleted && c.OnDate.Date.Month == DateTime.Today.AddMonths(-1).Month && c.OnDate.Date.Year == DateTime.Today.Year)?.Sum(c => c.TotalPrice)) ?? 0;
            return VM;
        }

    }
}
