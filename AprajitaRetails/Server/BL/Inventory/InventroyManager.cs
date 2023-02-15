using System;
using AprajitaRetails.Server.Data;
using Microsoft.EntityFrameworkCore;

namespace AprajitaRetails.Server.BL.Inventory
{
	public class InventroyManager
	{

		public static void CleanUpStock(ARDBContext db, string storeid)
		{
			var stockList = db.Stocks.Where(c => c.StoreId == storeid).ToList();

			foreach (var item in stockList)
			{
				item.HoldQty=item.PurchaseQty=item.SoldQty = 0;
			}

			var purchase = db.PurchaseItems.Include(c=>c.ProductItem).Include(c => c.PurchaseProduct).Where(c => c.PurchaseProduct.StoreId == storeid)
				.Select(c => new {c.Unit, c.ProductItem.MRP,  Qty = c.Qty + c.FreeQty, CostPrice = c.CostPrice, c.Barcode }).ToList();

			var sale = db.SaleItems.Include(c => c.ProductSale).Where(c => c.ProductSale.StoreId == storeid)
				.Select(c=>new {c.Barcode, c.BilledQty, c.FreeQty, c.InvoiceType })
				.ToList();



		}
	}
}

