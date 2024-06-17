using AprajitaRetails.Shared.Models.Bases;
using System.ComponentModel.DataAnnotations;

namespace AprajitaRetails.Shared.ViewModels
{
    public class PurchaseData
    {
        public int SN { get; set; }
        public DateTime InwardDate { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string SupplierName { get; set; }
        public string GSTIN { get; set; }
        public string InvoiceNumber { get; set; }
        public string StyleCode { get; set; }
        public string Barcode { get; set; }
        public string HSNCode { get; set; }
        public string Brand { get; set; }
        public string Category { get; set; }
        public decimal Quantity { get; set; }
        public decimal Rate { get; set; }

        public decimal UnitMRP { get; set; }
        public decimal TaxRate { get; set; }
        public decimal Discount { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal BasicValue { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal CostValue { get; set; }
        public decimal ExtraAmount { get; set; }
    }

    public class DailySaleVM : BaseST
    {
        [Key]
        public string InvoiceNumber { get; set; }

        public DateTime OnDate { get; set; }
        public decimal Amount { get; set; }
        public decimal CashAmount { get; set; }
        public decimal NonCashAmount { get; set; }
        public PayMode PayMode { get; set; }
        public string SalesmanName { get; set; }

        public bool IsDue { get; set; }
        public bool ManualBill { get; set; }
        public bool SalesReturn { get; set; }
        public bool TailoringBill { get; set; }
        public string Remarks { get; set; }
        public string TerminalName { get; set; }
        public string StoreName { get; set; }

#pragma warning disable CS0108 // 'DailySaleVM.EntryStatus' hides inherited member 'BaseST.EntryStatus'. Use the new keyword if hiding was intended.
        public EntryStatus EntryStatus { get; set; }
#pragma warning restore CS0108 // 'DailySaleVM.EntryStatus' hides inherited member 'BaseST.EntryStatus'. Use the new keyword if hiding was intended.
#pragma warning disable CS0108 // 'DailySaleVM.StoreId' hides inherited member 'BaseST.StoreId'. Use the new keyword if hiding was intended.
        public string StoreId { get; set; }
#pragma warning restore CS0108 // 'DailySaleVM.StoreId' hides inherited member 'BaseST.StoreId'. Use the new keyword if hiding was intended.
        public string SalesmanId { get; set; }
        public string? EDCTerminalId { get; set; }
    }


    public class LedgerDetail{
        public int Id{get;set;}
        public string LedgerName{get;set;}
        public DateTime OnDate{get;set;}
        public string VoucherType{get;set;}
        public string VoucherNumber{get;set;}
        public string PaymentMode{get;set;}
        public string? Naration{get;set;}
        public string? PaymentDetails{get;set;}
        public decimal InAmount{get;set;}
        public decimal OutAmount { get; set; }
    }
}