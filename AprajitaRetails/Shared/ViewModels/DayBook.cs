using System.ComponentModel.DataAnnotations.Schema;

namespace AprajitaRetails.Shared.ViewModels
{
    public class DayBook
    {
        public int Id { get; set; }
        public string ParticularsName { get; set; }
        public string VoucherType { get; set; }
        public string VoucherNumber { get; set; }
        public string Location { get; set; }
        public string Naration { get; set; }
        public decimal InAmount { get; set; }
        public decimal OutAmount { get; set; }
    }

    public class DayBookRequest
    {
        public DateTime? OnDate { get; set; }
        public string? StoreCode { get; set; }
        public string? StoreCodeName { get; set; }
        public bool CashVoucher { get; set; }
    }
    public class MonthViewRequest
    {
        public DateTime? OnDate { get; set; }
        public string? StoreCode { get; set; }
        public string? StoreCodeName { get; set; }
        public bool CashVoucher { get; set; }
        public ClientReportMode Mode { get; set; }
    }

    public class DayBookReturn
    {
        public string StoreCode { get; set; }
        public string Location { get; set; }
        public DateTime? OnDate { get; set; }
        public List<DayBook> DayBooks { get; set; }
    }
    public class MonthView
    {

        public int Id { get; set; }
        public string VoucherType { get; set; }
        public string VoucherNumber { get; set; }
        public string StoreCode { get; set; }
        public string Location { get; set; }
        public string ParticularsName { get; set; }
        public DateTime OnDate { get; set; }
        public decimal InAmount { get; set; }
        public decimal OutAmount { get; set; }
        public PayMode PayMode { get; set; }
        public string Naration { get; set; }
        [NotMapped]
        public bool IsExpense { get; set; } = false;
        [NotMapped]
        public bool IsIncome { get; set; } = false;
        [NotMapped]
        public bool IsReceipt { get; set; } = false;

    }
    public class MonthViewReturn
    {
        public DateTime OnDate { get; set; }
        public string FilterMode { get; set; }
        public ClientReportMode Mode { get; set; }
        public string Location { get; set; }
        public List<MonthView> MonthViews { get; set; }
    }
    public enum ClientReportMode { Store, StoreGroup, Client }
}