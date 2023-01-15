using AprajitaRetails.Shared.Models.Bases;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AprajitaRetails.Shared.Models.Inventory
{
    //[Table("V2_Suppliers")]
    public class Supplier
    {
        [Key]
        public string SupplierName { get; set; }

        public string Warehouse { get; set; }
    }

    public class ProductPurchase : BaseST
    {
        [Key]
        public string InwardNumber { get; set; }

        public DateTime InwardDate { get; set; }

        public string InvoiceNo { get; set; }
        public string VendorId { get; set; }

        public PurchaseInvoiceType InvoiceType { get; set; }
        public TaxType TaxType { get; set; }
        public DateTime OnDate { get; set; }

        public decimal BasicAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal TaxAmount { get; set; }

        public decimal ShippingCost { get; set; }

        public decimal TotalAmount { get; set; }

        public int Count { get; set; }

        public decimal BillQty { get; set; }
        public decimal FreeQty { get; set; }
        public decimal TotalQty { get; set; }

        public bool Paid { get; set; }

        public string Warehouse { get; set; }
        public virtual Vendor Vendor { get; set; }
        public virtual ICollection<PurchaseItem> Items { get; set; }
    }

    public class PurchaseItem
    {
        public int Id { get; set; }

        [ForeignKey("ProductPurchase")]
        public string InwardNumber { get; set; }

        [ForeignKey("Product")]
        public string Barcode { get; set; }

        public decimal Qty { get; set; }
        public decimal FreeQty { get; set; }
        public decimal CostPrice { get; set; }

        public Unit Unit { get; set; }

        public decimal DiscountValue { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal CostValue { get; set; }

        [ForeignKey("InwardNumber")]
        public virtual ProductPurchase PurchaseProduct { get; set; }

        [ForeignKey("Barcode")]
        public virtual ProductItem ProductItem { get; set; }
    }

    public class Vendor : BaseST
    {
        [Key]
        public string VendorId { get; set; }

        public string VendorName { get; set; }
        public VendorType VendorType { get; set; }
        public DateTime OnDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool Active { get; set; }
    }
}