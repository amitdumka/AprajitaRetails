using AprajitaRetails.Shared.Models.Bases;
using System.ComponentModel.DataAnnotations;

namespace AprajitaRetails.Shared.Models.Stores
{
    public class DailySale : BaseST
    {
        [Key]
        public string InvoiceNumber { get; set; }

        public DateTime OnDate { get; set; }
        public decimal Amount { get; set; }
        public decimal CashAmount { get; set; }
        public decimal NonCashAmount { get; set; }
        public PayMode PayMode { get; set; }
        public string SalesmanId { get; set; }

        public bool IsDue { get; set; }

        public bool ManualBill { get; set; }
        public bool SalesReturn { get; set; }
        public bool TailoringBill { get; set; }
        public string? Remarks { get; set; }

        public string? EDCTerminalId { get; set; }
        public virtual EDCTerminal EDC { get; set; }
        public virtual Salesman Salesman { get; set; }
    }

    //TODO: Move to VM

    public class EDCTerminal : BaseST
    {
        public string EDCTerminalId { get; set; }
        public string Name { get; set; }
        public DateTime OnDate { get; set; }
        public string TID { get; set; }
        public string MID { get; set; }
        public string BankId { get; set; }
        public string ProviderName { get; set; }
        public DateTime? CloseDate { get; set; }
        public bool Active { get; set; }
    }

    public class CustomerDue : BaseST
    {
        [Key]
        public string InvoiceNumber { get; set; }

        public DateTime OnDate { get; set; }
        public decimal Amount { get; set; }
        public bool Paid { get; set; }
        public DateTime? ClearingDate { get; set; }
    }

    public class DueRecovery : BaseST
    {
        public string Id { get; set; }
        public DateTime OnDate { set; get; }
        public string InvoiceNumber { set; get; }
        public decimal Amount { set; get; }
        public PayMode PayMode { get; set; }
        public string? Remarks { get; set; }
        public bool PartialPayment { get; set; }
        public virtual CustomerDue Due { get; set; }

        public static string GenerateId(string inv, DateTime onDate)
        {
            return $"DR-{onDate.Year}-{onDate.Month}-{onDate.Day}-{inv}-";
        }
    }
}