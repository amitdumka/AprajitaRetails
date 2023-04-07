using System;
using AprajitaRetails.Server.Data;
using Microsoft.EntityFrameworkCore;

namespace AprajitaRetails.Server.BL.Reports.Inventory
{
	public class SaleReports
	{
		public static void GenerateSaleReportForGST(ARDBContext db, int Month, int Year)
		{

			var saleData = db.SaleItems.Include(c => c.ProductSale).Where(c => c.ProductSale.OnDate.Year == Year && c.ProductSale.OnDate.Month == Month)
				.Select(c => new {c.Barcode, c.BilledQty, c.FreeQty, c.BasicAmount, c.DiscountAmount, c.TaxAmount, c.Value,c.ProductSale.StoreId })
				.ToList();

		}
	}
}

