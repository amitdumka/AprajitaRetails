using System.ComponentModel.DataAnnotations;

namespace AprajitaRetails.Shared.Models.Mobile
{
    public class MStore
    {
        [Key]
        public string StoreId { get; set; }

        public string StoreName { get; set; }
        public string City { get; set; }
        public string TaxNumber { get; set; }
        public string StoreGroupId { get; set; }
    }

    public class MEmployee
    {
        [Key]
        public string EmployeeId { get; set; }

        public string EmployeeName { get; set; }
        public string StoreId { get; set; }
        public bool Working { get; set; }
        public EmpType Category { get; set; }
    }

    public class MLedger
    {
        [Key]
        public string LegderId { get; set; }

        public string LegderName { get; set; }
        public string StoreGroupId { get; set; }
        public string StoreId { get; set; }
    }

    public class MBankAccount
    {
        [Key]
        public string AccountNumber { get; set; }

        public string AccountName { get; set; }
        public string StoreGroupId { get; set; }
    }

    public class MStock
    {
        [Key]
        public string StockId { get; set; }

        public string Barcode { get; set; }
        public string ProductName { get; set; }
        public decimal Cost { get; set; }
        public decimal MRP { get; set; }
        public Unit Unit { get; set; }

        public decimal Quantity { get; set; }

        public string StoreId { get; set; }
        public DateTime SyncDate { get; set; }
    }

    public class MProduct
    {
        [Key]
        public string Barcode { get; set; }

        public string ProductName { get; set; }
        public decimal Cost { get; set; }
        public decimal MRP { get; set; }
        public Unit Unit { get; set; }
        public string StoreGroudId { get; set; }
    }
}