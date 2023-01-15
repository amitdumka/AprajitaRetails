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

        public EntryStatus EntryStatus { get; set; }
        public string StoreId { get; set; }
        public string SalesmanId { get; set; }
        public string? EDCTerminalId { get; set; }
    }
}