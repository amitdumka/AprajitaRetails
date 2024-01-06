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

    public class DayBookReturn
    {
        public string StoreCode { get; set; }
        public string Location { get; set; }
        public DateTime? OnDate { get; set; }
        public List<DayBook> DayBooks { get; set; }
    }
}