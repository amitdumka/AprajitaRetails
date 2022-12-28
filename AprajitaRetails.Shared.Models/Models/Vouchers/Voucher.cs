using System;
using System.Collections.Generic;
using System.Text;

namespace AprajitaRetails.Shared.Models.Models.Vouchers
{
    public class Voucher
    {
        [Key]
        public string VoucherNo { get; set; }
        public string VoucherType { get; set;}
        public DateTime OnDate { get; set; }
        public string PaidTo { get; set; }
        public decimal Amount { get; set; }
        public string PayMode { get; set; }
        public string PaymentDetails { get; set; }
        public string Remarks { get; set; }
        public string IssuedBy { get; set; }
        public string PartyId { get; set; }

    }

    public class CashVoucher
    {
        [Key]
        public string CashVoucherNo { get; set; }
        public string TranscationCategoryId { get; set; }
        public string VoucherType { get; set; }
        public DateTime OnDate { get; set; }
        public string PaidTo { get; set; }
        public decimal Amount { get; set; }
        public string Remarks { get; set; }
        public string IssuedBy { get; set; }
    }



}
