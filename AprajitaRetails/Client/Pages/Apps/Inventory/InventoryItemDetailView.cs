using System;
using System.ComponentModel.DataAnnotations;

namespace AprajitaRetails.Client.Pages.Apps.Inventory
{
	public partial class InventoryItemDetailView
	{
		protected InventoryItem? Item = null;
		public InventoryItemDetailView()
		{

		}
	}


	public class InventoryItem
	{
		[Key]
		public string InvoiceNumber { get; set; }
		public DateTime OnDate { get; set; }
		public decimal BillAmount { get; set; }
		public decimal TaxAmount { get; set; }
		public decimal BasicAmount { get; set; }
		public decimal DiscountAmount { get; set; }
		public decimal BillQty { get; set; }
		public IEnumerable<InventoryItemDetail>? Items { get; set; }
	}

	public class InventoryItemDetail
	{
		public string InvoiceNumber { get; set; }
		public string Barcode { get; set; }
		public string ProductName { get; set; }
        public decimal Qty { get; set; }
        public Unit Unit { get; set; }
        public decimal Rate { get; set; }		
		public decimal Discount { get; set; }
		public decimal BasicAmount { get; set; }
		public decimal TaxAmount { get; set; }
		public decimal Amount { get; set; }
		

	}
}

