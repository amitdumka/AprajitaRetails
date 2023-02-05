using System;
namespace AprajitaRetails.Shared.ViewModels.Dashboards
{
	public class DashboardVM
	{
		public string StoreId { get; set; }

		public decimal TodaySale { get; set; }
        public decimal MonhtlySale { get; set; }
        public decimal WeeklySale { get; set; }
        public decimal YearlySale { get; set; }
        public decimal QuatarlySale { get; set; }

        public decimal YearlyPayments { get; set; }
        public decimal YearlyReciepts { get; set; }
        public decimal YearlyExpenses { get; set; }

        public decimal MonthlyPayments { get; set; }
        public decimal MonthlyReciepts { get; set; }
        public decimal MonthlyExpenses { get; set; }

        public decimal YearlySalaries { get; set; }
        public decimal MonthlySalaries { get; set; }
        public decimal QuartlyExpenses { get; set; }
 
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

