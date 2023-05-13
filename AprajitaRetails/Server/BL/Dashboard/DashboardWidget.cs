using AprajitaRetails.Server.Data;
using AprajitaRetails.Shared.ViewModels.Dashboards;
using Microsoft.EntityFrameworkCore;

namespace AprajitaRetails.Server.BL.Dashboard
{
    public class DashboardWidget
    {

        DashboardVM VM;

        public async Task<DashboardVM> GenerateDashboard(string storeid, ARDBContext db)
        {

            VM = new DashboardVM ();
            try
            {
                //var x = db.ProductSales.GroupBy(c => new { c.OnDate.Year, c.OnDate.Month, c.OnDate.Day })
                //    .Where(c => c.Key.Day == DateTime.Today.Day && c.Key.Year == DateTime.Today.Year && c.Key.Month == DateTime.Today.Month).
                //    Select(c => new { T = c.Sum(x => x.TotalPrice) });

                // VM.TodaySale=db.ProductSales.GroupBy(c => c.OnDate.Date).Where(c => c.StoreId == storeid && !c.MarkedDeleted && c.OnDate.Date == DateTime.Today.Date)
                // Generate Sale Report 
                //VM.TodaySale = (decimal)((decimal?) db.ProductSales.Where(c => c.StoreId == storeid && !c.MarkedDeleted && c.OnDate.Date == DateTime.Today.Date)?.Sum(c =>(decimal?) c.TotalPrice) ??0);

                VM.TodaySale = ((decimal?)(db.ProductSales.Where(c => c.StoreId == storeid && !c.MarkedDeleted && c.OnDate.Date == DateTime.Today.Date))?.Select(c => c.TotalPrice)?.Sum()) ?? 0;
                VM.YesterdaySale = ((decimal?)db.ProductSales.Where(c => c.StoreId == storeid && !c.MarkedDeleted && c.OnDate.Date == DateTime.Today.AddDays(-1).Date)?.Select(c => c.TotalPrice).Sum()) ?? 0;
                VM.LastMonthSale = ((decimal?)db.ProductSales.Where(c => c.StoreId == storeid && !c.MarkedDeleted && c.OnDate.Date.Month == DateTime.Today.AddMonths(-1).Month && c.OnDate.Date.Year == DateTime.Today.Year)?.Sum(c => c.TotalPrice)) ?? 0;


                VM.YearlySale = ((decimal?)db.ProductSales.Where(c => c.StoreId == storeid && !c.MarkedDeleted && c.OnDate.Date.Year == DateTime.Today.Year)?.Sum(c => c.TotalPrice)) ?? 0;
                VM.MonthlySale = ((decimal?)db.ProductSales.Where(c => c.StoreId == storeid && !c.MarkedDeleted && c.OnDate.Date.Month == DateTime.Today.Month && c.OnDate.Date.Year == DateTime.Today.Year)?.Sum(c => c.TotalPrice)) ?? 0;
                VM.QuarterlySale = ((decimal?)db.ProductSales.Where(c => c.OnDate.Year == DateTime.Today.Year && c.OnDate.Month >= (DateTime.Today.Month - 2))?.Sum(c => c.TotalPrice)) ?? 0;

                //Salary
                VM.YearlySalaries = (decimal?)db.SalaryPayments.Where(c => c.StoreId == storeid && !c.MarkedDeleted && c.OnDate.Year == DateTime.Today.Year)?.Select(c => c.Amount)?.Sum() ?? 0;

                VM.MonthlySalaries = (decimal?)db.SalaryPayments.Where(c => c.StoreId == storeid && !c.MarkedDeleted && c.OnDate.Year == DateTime.Today.Year && c.OnDate.Month == DateTime.Today.Month)?.Select(c => c.Amount)?.Sum() ?? 0;
                VM.QuarterlySalaries = (decimal?)db.SalaryPayments.Where(c => c.StoreId == storeid && !c.MarkedDeleted && c.OnDate.Year == DateTime.Today.Year && c.OnDate.Month >= DateTime.Today.AddMonths(-2).Month)?.Select(c => c.Amount)?.Sum() ?? 0;




                //Yearly expenses

                var vch = db.Vouchers.Where(c => c.StoreId == storeid && !c.MarkedDeleted && c.OnDate.Date.Year == DateTime.Today.Year).GroupBy(c => c.VoucherType)
                        .Select(c => new { VCH = c.Key, Amount = c.Sum(x => x.Amount) }).ToList();

                var vch2 = db.CashVouchers.Where(c => c.StoreId == storeid && !c.MarkedDeleted && c.OnDate.Date.Year == DateTime.Today.Year).GroupBy(c => c.VoucherType)
                        .Select(c => new { VCH = c.Key, Amount = c.Sum(x => x.Amount) }).ToList();

                if (vch!=null && vch.Any())
                {
                    foreach (var item in vch)
                    {
                        switch (item.VCH)
                        {
                            case VoucherType.Payment: VM.YearlyPayments = item.Amount;break;
                            case VoucherType.Receipt: VM.YearlyReceipts = item.Amount; break;
                            case VoucherType.Expense: VM.YearlyExpenses = item.Amount; break;
                            default:
                                break;
                        }
                    }
                }


                if (vch2 != null && vch2.Any())
                {
                    foreach (var item in vch2)
                    {
                        switch (item.VCH)
                        {
                            case VoucherType.CashPayment: VM.YearlyPayments += item.Amount; break;
                            case VoucherType.CashReceipt: VM.YearlyReceipts += item.Amount; break;
                           // case VoucherType.Expense: VM.YearlyExpenses += item.Amount; break;
                            default:
                                break;
                        }
                    }
                }
                //Monhtly
                var vch3 = db.Vouchers.Where(c => c.StoreId == storeid && !c.MarkedDeleted && c.OnDate.Date.Year == DateTime.Today.Year && c.OnDate.Month==DateTime.Today.Month).GroupBy(c => c.VoucherType)
                        .Select(c => new { VCH = c.Key, Amount = c.Sum(x => x.Amount) }).ToList();

                var vch4 = db.CashVouchers.Where(c => c.StoreId == storeid && !c.MarkedDeleted && c.OnDate.Date.Year == DateTime.Today.Year && c.OnDate.Month == DateTime.Today.Month).GroupBy(c => c.VoucherType)
                        .Select(c => new { VCH = c.Key, Amount = c.Sum(x => x.Amount) }).ToList();

                if (vch3 != null && vch3.Any())
                {
                    foreach (var item in vch3)
                    {
                        switch (item.VCH)
                        {
                            case VoucherType.Payment: VM.MonthlyPayments = item.Amount; break;
                            case VoucherType.Receipt: VM.MonthlyReceipts = item.Amount; break;
                            case VoucherType.Expense: VM.MonthlyExpenses = item.Amount; break;
                            default:
                                break;
                        }
                    }
                }
                if (vch4 != null && vch4.Any())
                {
                    foreach (var item in vch4)
                    {
                        switch (item.VCH)
                        {
                            case VoucherType.CashPayment: VM.MonthlyPayments += item.Amount; break;
                            case VoucherType.CashReceipt: VM.MonthlyReceipts += item.Amount; break;
                            //case VoucherType.C: VM.MonthlyExpenses += item.Amount; break;
                            default:
                                break;
                        }
                    }
                }


                // Employee
                var emps = db.Attendances.Include(c => c.Employee).Where(c => c.StoreId == storeid && c.OnDate.Date == DateTime.Today.Date)
                   .Select(c => new { c.EmployeeId, c.Employee.StaffName, c.Status ,c.Employee.Category}).ToList();

                var attcnt = db.Attendances.Where(c =>  c.StoreId == storeid  && c.OnDate.Month == DateTime.Today.Month && c.OnDate.Year==DateTime.Today.Year)
                    .GroupBy(c=>new { c.EmployeeId, c.Status })
                    .Select(c => new { c.Key.EmployeeId, Present=c.Count(c=>c.Status==AttUnit.Present)+(decimal) ((decimal)0.5*c.Count(x=>x.Status==AttUnit.HalfDay)) }).ToList();

                var sales = db.ProductSales.Include(c=>c.Salesman).Where(c => c.OnDate.Year == DateTime.Today.Year && c.OnDate.Month == DateTime.Today.Month && c.StoreId == storeid)
                    .Select(c => new { c.SalesmanId, c.Salesman.EmployeeId, c.TotalPrice })
                    .GroupBy(c=>c.EmployeeId).Select(c=>new {c.Key, Sale=c.Sum(c=>c.TotalPrice) })
                    .ToList();

                VM.PayrollInfo = new PayrollInfo();
                VM.PayrollInfo.StoreId = storeid;
                VM.PayrollInfo.Emps = new List<EmpInfo>();
                foreach (var item in emps)
                {
                    EmpInfo emp = new EmpInfo { Name=item.StaffName, Today=item.Status, TotalSale=sales.Where(c=>c.Key==item.EmployeeId).FirstOrDefault()?.Sale??0, Present=attcnt.Where(c=>c.EmployeeId==item.EmployeeId).FirstOrDefault()?.Present??0 };
                    VM.PayrollInfo.Emps.Add(emp);
                }



                return VM;
            }

            catch (Exception ex)
            {
                return VM;
            }



        }

    }
}
