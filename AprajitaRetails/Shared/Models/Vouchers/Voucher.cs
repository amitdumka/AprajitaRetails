using AprajitaRetails.Shared.Models.Bases;
using AprajitaRetails.Shared.Models.Payroll;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AprajitaRetails.Shared.Models.Vouchers
{
    public class Voucher : BaseST
    {
        [Key]
        public string VoucherNumber { get; set; }

        public VoucherType VoucherType { get; set; }
        public DateTime OnDate { get; set; }
        public string SlipNumber { get; set; }

        public string PartyName { get; set; }

        public string Particulars { get; set; }

        public decimal Amount { get; set; }
        public PaymentMode PaymentMode { get; set; }
        public string? PaymentDetails { get; set; }
        public string? Remarks { get; set; }
        public string? AccountId { get; set; }

        public string EmployeeId { get; set; }
        public virtual Employee? Employee { get; set; }

        public string PartyId { get; set; }
        public virtual Party? Party { get; set; }
    }

    public class TransactionMode
    {
        [Key]
        public string TransactionId { get; set; }

        public string TransactionName { get; set; }
    }

    public class CashVoucher : BaseST
    {
        [Key]
        public string VoucherNumber { get; set; }

        public VoucherType VoucherType { get; set; }
        public DateTime OnDate { get; set; }

        public string TransactionId { get; set; }

        [ForeignKey("TransactionId")]
        public virtual TransactionMode? TransactionMode { get; set; }

        public string SlipNumber { get; set; }
        public string PartyName { get; set; }
        public string Particulars { get; set; }
        public decimal Amount { get; set; }
        public string Remarks { get; set; }
        public string EmployeeId { get; set; }
        public virtual Employee? Employee { get; set; }

        public string PartyId { get; set; }
        public virtual Party? Partys { get; set; }
    }

    public class Note : BaseST
    {
        [Key]
        public string NoteNumber { get; set; }

        public NotesType NotesType { get; set; }
        public DateTime OnDate { get; set; }

        public string PartyName { get; set; }
        public bool WithGST { get; set; }
        public decimal Amount { get; set; }
        public decimal TaxRate { get; set; }

        public decimal TaxAmount
        { get { return (Amount * (TaxRate / 100)); } }

        public decimal NetAmount
        { get { return Amount + TaxAmount; } }

        public string Reason { get; set; }
        public string Remarks { get; set; }

        public string PartyId { get; set; }
        public virtual Party? Party { get; set; }
    }

    public class LedgerGroup
    {
        [Key]
        public string LedgerGroupId { get; set; }

        public string GroupName { get; set; }
        public LedgerCategory Category { get; set; }
        public string? Remark { get; set; }
    }

    public class Party : BaseST
    {
        public string PartyId { get; set; }
        public string PartyName { get; set; }
        public DateTime OpeningDate { get; set; }
        public DateTime? ClosingDate { get; set; }
        public decimal OpeningBalance { get; set; }
        public decimal ClosingBalance { get; set; }
        public LedgerCategory Category { get; set; }
        public string? GSTIN { get; set; }
        public string? PANNo { get; set; }
        public string? Address { get; set; }
        public string? Remarks { get; set; }
        public string LedgerGroupId { get; set; }
        public virtual LedgerGroup LedgerGroup { get; set; }
    }

    public class LedgerMaster
    {
        [Key]
        public string PartyId { get; set; }

        public string PartyName { get; set; }
        public DateTime OpeningDate { get; set; }
    }

    public class PettyCashSheet : BaseST
    {
        public string Id { get; set; }
        public DateTime OnDate { get; set; }

        //Balance
        public decimal OpeningBalance { get; set; }

        public decimal ClosingBalance { get; set; }

        //Bank
        public decimal BankDeposit { get; set; }

        public decimal BankWithdrawal { get; set; }

        //Sale
        public decimal DailySale { get; set; }

        public decimal TailoringSale { get; set; }
        public decimal TailoringPayment { get; set; }

        //Different Sale
        public decimal ManualSale { get; set; }

        public decimal CardSale { get; set; }
        public decimal NonCashSale { get; set; }

        public decimal CustomerDue { get; set; }
        public string DueList { get; set; }
        public decimal CustomerRecovery { get; set; }
        public string RecoveryList { get; set; }

        public string ReceiptsNarration { get; set; }
        public decimal ReceiptsTotal { get; set; }

        public string PaymentNarration { get; set; }
        public decimal PaymentTotal { get; set; }
    }
}