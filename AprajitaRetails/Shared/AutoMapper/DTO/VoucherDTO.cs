using System;
using AprajitaRetails.Shared.Models.Bases;
using AprajitaRetails.Shared.Models.Payroll;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AprajitaRetails.Shared.AutoMapper.DTO
{
    public class VoucherDTO
    {
        [Key]
        [Display(Name ="VCH No")]
        public string VoucherNumber { get; set; }

        [Display(Name ="VCH Type")]
        public VoucherType VoucherType { get; set; }
        [Display(Name ="Date")]
        public DateTime OnDate { get; set; }
        [Display(Name ="Slip #")]
        public string SlipNumber { get; set; }
        [Display(Name ="Party")]
        public string PartyName { get; set; }

        public string Particulars { get; set; }

        public decimal Amount { get; set; }
        [Display(Name ="Mode")]
        public PaymentMode PaymentMode { get; set; }
        [Display(Name ="Details")]
        public string PaymentDetails { get; set; }
        public string Remarks { get; set; }
        [Display(Name ="Acc/No")]
        public string AccountNumber { get; set; }
        public string EmployeeId { get; set; }

        [Display(Name = "Issued By")]
        public string StaffName { get; set; }

        public string PartyId { get; set; }
        [Display(Name ="Ledger")]
        public string LedgerName { get; set; }

        public string StoreId { get; set; }
        [Display(Name ="Store")]
        public string StoreName { get; set; }
    }

    public class CashVoucherDTO
    {
        [Key]
        public string VoucherNumber { get; set; }

        public VoucherType VoucherType { get; set; }
        public DateTime OnDate { get; set; }

        public string TransactionId { get; set; }

        [Display(Name = "Transaction")]
        public string TransactionName { get; set; }

        public string SlipNumber { get; set; }
        public string PartyName { get; set; }
        public string Particulars { get; set; }
        public decimal Amount { get; set; }
        public string Remarks { get; set; }
        public string EmployeeId { get; set; }

        [Display(Name = "Issued By")]
        public string StaffName { get; set; }

        public string PartyId { get; set; }
        public string LedgerName { get; set; }

        public string StoreId { get; set; }
        public string StoreName { get; set; }
    }

    public class NoteDTO
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
        public string LedgerName { get; set; }

        public string StoreId { get; set; }
        public string StoreName { get; set; }
    }

    public class PartyDTO
    {
        public string PartyId { get; set; }
        public string PartyName { get; set; }
        public DateTime OpeningDate { get; set; }
        public DateTime? ClosingDate { get; set; }
        public decimal OpeningBalance { get; set; }
        public decimal ClosingBalance { get; set; }
        public LedgerCategory Category { get; set; }
        public string GSTIN { get; set; }
        public string PANNo { get; set; }
        public string Address { get; set; }
        public string Remarks { get; set; }
        public string LedgerGroupId { get; set; }
        public string GroupName { get; set; }
        public string StoreId { get; set; }
        public string StoreName { get; set; }
    }
}