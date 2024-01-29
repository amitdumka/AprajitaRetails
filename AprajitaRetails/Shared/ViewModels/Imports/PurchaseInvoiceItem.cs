using System.ComponentModel.DataAnnotations;

namespace AprajitaRetails.Shared.ViewModels.Imports
{

    public class ReturnData
    {
        public decimal Added { get; set; } = 0;

        public bool Error { get; set; } = false;

        public string ErrorMessage { get; set; } = string.Empty;

        public string Message { get; set; } = string.Empty;

        public decimal SavedToDB { get; set; } = 0;

        public decimal Skipped { get; set; } = 0;

        public bool Success { get; set; } = false;
    }

    public class PurchaseInvoiceItem
    {

        [Key]
        public int SN { get; set; }
        public string StoreCode { get; set; }
        public DateTime InwardDate { get; set; }
        public string InwardNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string InvoiceNumber { get; set; }

        public string SupplierName { get; set; }
        public string Barcode { get; set; }
        public string HSNCODE { get; set; }
        public string ProductName { get; set; }

        public string StyleCode { get; set; }
        public string ProductCategory { get; set; }

        public string ProductDescription { get; set; }
        public string Size { get; set; }
        public decimal Quantity { get; set; }
        public string Unit { get; set; }
        public decimal UnitCost { get; set; }
        public decimal UnitMRP { get; set; }

        public decimal MRPValue { get; set; }
        public decimal DiscoutP { get; set; }
        public decimal CostValue { get; set; }
        public decimal IGST_CGSTAmount { get; set; }
        public decimal IGST_CGSTRate { get; set; }
        public decimal SGSTAmount { get; set; }
        public decimal SGSTRate { get; set; }

        public decimal Amount { get; set; }
        public decimal RoundOff { get; set; }
        public decimal BillAmount { get; set; }




















    }

    ///SN	InwardNumber	InwardDate	InvoiceNumber	InvoiceDate	SupplierName	StoreCode	ProductCategory	Barcode	ProductName	StyleCode	ProductDescription	HSNCODE	Size	Unit	Quantity	UnitMRP	MRPValue	UnitCost	CostValue	IGST_CGSTRate	SGSTRate	IGST_CGSTAmount	SGSTAmount	Amount	RoundOff	BillAmount
}

