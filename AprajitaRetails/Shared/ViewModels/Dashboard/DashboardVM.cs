using System;
namespace AprajitaRetails.Shared.ViewModels.Dashboards
{
	public class DashboardVM
	{
		public string StoreId { get; set; }

        //Sale
        public decimal? TodaySale { get; set; } = 0;
        public decimal? YesterdaySale { get; set; } = 0;

        public decimal? MonthlySale { get; set; } = 0;
        public decimal? LastMonthSale { get; set; } = 0;

        public decimal? WeeklySale { get; set; } = 0;
        public decimal? YearlySale { get; set; } = 0;

        public decimal? QuarterlySale { get; set; } = 0;

        //Voucher
        public decimal? YearlyPayments { get; set; } = 0;
        public decimal? YearlyReceipts { get; set; } = 0;
        public decimal? YearlyExpenses { get; set; } = 0;

        public decimal? MonthlyPayments { get; set; } = 0;
        public decimal? MonthlyReceipts { get; set; } = 0;
        public decimal? MonthlyExpenses { get; set; } = 0;

        //Salary
        public decimal? YearlySalaries { get; set; } = 0;
        public decimal? MonthlySalaries { get; set; } = 0;
        public decimal? QuarterlySalaries{ get; set; } = 0;

        public PayrollInfo PayrollInfo { get; set; }
 
    }

    public class PayrollInfo
    {
        public string StoreId { get; set; }
        public List<EmpInfo> Emps { get; set; }
 
    }

    public class EmpInfo
    {
        public string Name { get; set; }
        public AttUnit Today { get; set; }
        public decimal Present { get; set; }
        public decimal TotalSale { get; set; }

    }

     
}

