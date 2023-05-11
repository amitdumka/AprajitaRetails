using System;
using AprajitaRetails.Server.Data;

namespace AprajitaRetails.Server.BL.Inventory
{
	//Storewise Sale Report[Details report]
	//Impelemt For 5 Yearly V/s Total Span. 
	public class SaleReport
	{
		public string StoreName { get; set; }
		public string StoreCode { get; set; }

		//Sale
		public decimal TodaySale { get; set; }
		public decimal YesterdaySale { get; set; }

		public decimal MonthlySale { get; set; }
		public decimal LastMonthSale { get; set; }

		public decimal YearlySale { get; set; }
		public decimal LastYearSale { get; set; }

		public decimal[] QuartlySale { get; set; } = new decimal[4];

		public decimal[] QuartlyPurchase { get; set; } = new decimal[4];

		public decimal YearlyPurchase { get; set; }
		public decimal LastYearPurchase { get; set; }

		//Qty

		public decimal TodayQty { get; set; }
		public decimal YesterdayQty { get; set; }

		public decimal MonthlyQty { get; set; }
		public decimal YearlyQty { get; set; }
		public decimal[] QuartlyQty { get; set; } = new decimal[4];

		


		private ARDBContext aRDB;
		public SaleReport(ARDBContext db)
		{
			aRDB = db;
		}

		public void GetReport(string storeid)
		{
			//return error
			if (string.IsNullOrEmpty(storeid)) return;

			

		}
		private void SetSaleData(string storeid)
		{
			var sale = aRDB.ProductSales.Where(c => c.StoreId == storeid && !c.MarkedDeleted && c.OnDate.Date.Year == DateTime.Today.Year)
				.Select(c => new {c.OnDate, c.BilledQty, c.TotalPrice})
				.GroupBy(c=>c.OnDate)
				.Select(c=>new {OnDate= c.Key, Qty= c.Sum(k=>k.BilledQty), Amount=c.Sum(k=>k.TotalPrice) })
				.ToList();

			//Current
			TodaySale = sale.Where(c => c.OnDate == DateTime.Today).FirstOrDefault().Amount;
            YesterdaySale=sale.Where(c => c.OnDate == DateTime.Today.AddDays(-1)).FirstOrDefault().Amount;
            TodayQty = sale.Where(c => c.OnDate == DateTime.Today).FirstOrDefault().Amount;
            YesterdayQty = sale.Where(c => c.OnDate == DateTime.Today.AddDays(-1)).FirstOrDefault().Qty;

            //Monthly
            MonthlySale = sale.Where(c => c.OnDate.Year == DateTime.Today.Year && c.OnDate.Month == DateTime.Today.Month).Sum(c => c.Amount);
            MonthlyQty = sale.Where(c => c.OnDate.Year == DateTime.Today.Year && c.OnDate.Month == DateTime.Today.Month).Sum(c => c.Qty);

            LastMonthSale = sale.Where(c => c.OnDate.Year == DateTime.Today.Year && c.OnDate.Month == DateTime.Today.Month-1).Sum(c => c.Amount);

			//Year
			YearlySale= sale.Where(c => c.OnDate.Year == DateTime.Today.Year).Sum(c => c.Amount);
            YearlyQty= sale.Where(c => c.OnDate.Year == DateTime.Today.Year).Sum(c => c.Qty);

			//Quartly Sale/Qty



        }

	}
}

