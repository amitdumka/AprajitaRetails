using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AprajitaRetails.Shared.Models.Tally
{
    public class TallyMapping
    {
        public int Id { get; set; } 
        public string LedgerName { get; set; }
        public string LedgerId {  get; set; }
        public int MasterId {  get; set; }
        public string PartyLedgerName { get; set; }
        public bool IsMapped {  get; set; }
        public string LedgerType { get; set; }
    }


    public class TallyExpenseVoucher
    {
        public int Id { get; set; }
        public string LedgerName { get; set; }
        public string LedgerId { get;set; }
        public int MasterId { get; set; }
        public string PartyName {  get; set; }
    }
    public class TallyReceiptVoucher
    {
        public int Id { get; set; }
        public string LedgerName { get; set; }
        public string LedgerId { get; set; }
        public int MasterId { get; set; }
        public string PartyName { get; set; }
    }

    public class TallyEmployeeVoucher
    {
        public int Id { get; set; }
        public string LedgerName { get; set; }
        public string LedgerId { get; set; }
        public int MasterId { get; set; }
        public string PartyName { get; set; }
    }
    public class TallySalesVoucher
    {
        public int Id { get; set; }
        public string LedgerName { get; set; }
        public string LedgerId { get; set; }
        public int MasterId { get; set; }
        public string PartyName { get; set; }
    }
    public class TallyPurchaseVoucher
    {
        public int Id { get; set; }
        public string LedgerName { get; set; }
        public string LedgerId { get; set; }
        public int MasterId { get; set; }
        public string PartyName { get; set; }
    }
    public class TallyVendorVoucher
    {
        public int Id { get; set; }
        public string LedgerName { get; set; }
        public string LedgerId { get; set; }
        public int MasterId { get; set; }
        public string PartyName { get; set; }
    }

    public class TallyMappedData
    {
        public int Id { get; set; }
        public string DataType {  get; set; }
        public string DataRefenceNumber {  get; set; }
        public int MasterId { get; set; }
        public string TallyRefernceId {  get; set; }
        public string LastOperationStatus {  get; set; }
        public DateTime LastOperationDate { get; set; }

    }

}
