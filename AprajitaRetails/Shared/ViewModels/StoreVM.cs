using AprajitaRetails.Shared.Models.Bases;
using System.ComponentModel.DataAnnotations;

namespace AprajitaRetails.Shared.ViewModels
{
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