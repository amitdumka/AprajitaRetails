﻿using System;
namespace AprajitaRetails.Shared.ViewModels.Dashboards
{
	public class DashboardVM
	{
		public string StoreId { get; set; }

        //Sale
		public decimal TodaySale { get; set; }
        public decimal YesterdaySale { get; set; }

        public decimal MonthlySale { get; set; }
        public decimal LastMonthSale { get; set; }

        public decimal WeeklySale { get; set; }
        public decimal YearlySale { get; set; }
        
        public decimal QuarterlySale { get; set; }

        //Voucher
        public decimal YearlyPayments { get; set; }
        public decimal YearlyReceipts { get; set; }
        public decimal YearlyExpenses { get; set; }

        public decimal MonthlyPayments { get; set; }
        public decimal MonthlyReceipts { get; set; }
        public decimal MonthlyExpenses { get; set; }

        //Salary
        public decimal YearlySalaries { get; set; }
        public decimal MonthlySalaries { get; set; }
        public decimal QuarterlyExpenses { get; set; }

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

