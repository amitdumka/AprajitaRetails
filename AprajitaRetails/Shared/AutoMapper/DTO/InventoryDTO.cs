using AprajitaRetails.Shared.Models.Inventory;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AprajitaRetails.Shared.AutoMapper.DTO
{
    public class ProductItemDTO
    {
        [Key]
        public string Barcode { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string StyleCode { get; set; }

        public TaxType TaxType { get; set; }
        public decimal MRP { get; set; }
        public Size Size { get; set; }

        //Category
        public ProductCategory ProductCategory { get; set; }

        public string SubCategory { get; set; }
        public string? ProductTypeId { get; set; }
        public string? ProductTypeName { get; set; }

        public string HSNCode { get; set; }
        public Unit Unit { get; set; }

        public string BrandCode { get; set; }

        //FKs
        [ForeignKey("BrandCode")]
        public string BrandName { get; set; }


    }

    public class ProductPurchaseDTO
    {

        [Key]
        public string InwardNumber { get; set; }

        public DateTime InwardDate { get; set; }

        public string InvoiceNo { get; set; }
        public string VendorId { get; set; }
        public string VendorName { get; set; }

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
        public string StoreId { get; set; }
        public string StoreName { get; set; }
    }

    public class VendorDTO
    {
        [Key]
        public string VendorId { get; set; }

        public string VendorName { get; set; }
        public VendorType VendorType { get; set; }
        public DateTime OnDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool Active { get; set; }
        public string StoreId { get; set; }
        public string StoreName { get; set; }
    }

    public class CustomerSale
    {
        [Key]
        public string InvoiceNumber { get; set; }
        public string MobileNo { get; set; }
        public string CustomerName { get; set; }
        public string StoreId { get; set; }
        public string StoreName { get; set; }

    }

    public class ProductSaleDTO
    {
        [Key]
        public string InvoiceNo { get; set; }

        public DateTime OnDate { get; set; }
        public InvoiceType InvoiceType { get; set; }

        public decimal BilledQty { get; set; }
        public decimal FreeQty { get; set; }

        public decimal TotalQty
        { get { return BilledQty + FreeQty; } }

        public decimal TotalMRP { get; set; }
        public decimal TotalDiscountAmount { get; set; }

        public decimal TotalBasicAmount { get; set; }
        public decimal TotalTaxAmount { get; set; }

        public decimal RoundOff { get; set; }
        public decimal TotalPrice { get; set; }

        // Manual Bill which is taxed or it become regular bill
        public bool Taxed { get; set; }

        public bool Adjusted { get; set; }

        //public virtual ICollection<SaleItem> Items { get; set; }
        public bool Paid { get; set; }

        public string SalesmanId { get; set; }
        public string SalemanName { get; set; }
        public bool Tailoring { get; set; }
        public string StoreId { get; set; }
        public string StoreName { get; set; }

    }

    public class SaleItemViewModel
    {
        public int Id { get; set; }
        public string Barcode { get; set; }

        public decimal BilledQty { get; set; }
        public decimal FreeQty { get; set; }
        public Unit Unit { get; set; }

        public decimal MRP { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal BasicAmount { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal Value { get; set; }

    }

    public class SaleItemDTO
    {
        public int Id { get; set; }

        public string InvoiceNumber { get; set; }

        public string Barcode { get; set; }
        public string ProductName { get; set; }

        public decimal BilledQty { get; set; }
        public decimal FreeQty { get; set; }
        public Unit Unit { get; set; }

        public decimal MRP { get; set; }
        public decimal DiscountAmount { get; set; }

        //Amount Without Tax
        public decimal BasicAmount { get; set; }

        //Tax on Total Amount(Total Tax {Vat/IGST/CGST+SGST})
        public decimal TaxAmount { get; set; }

        // Total Amount With Basic+total Tax
        public decimal Value { get; set; }

        // Type of Tax , Vat/IGST/ GST in case of local
        public TaxType TaxType { get; set; }

        // Type of Invoice like Regular or manual  => Sale return
        public InvoiceType InvoiceType { get; set; }

        public bool Adjusted { get; set; }
        public bool LastPcs { get; set; }

        public string StoreId { get; set; }
        public string StoreName { get; set; }
    }

    public class CardPaymentDetailDTO
    {
        public int Id { get; set; }
        public string InvoiceNumber { get; set; }
        public decimal PaidAmount { get; set; }
        public Card Card { get; set; }
        public CardType CardType { get; set; }
        public int CardLastDigit { get; set; }
        public int AuthCode { get; set; }
        public string? EDCTerminalId { get; set; }
        public string EDCTerminalName { get; set; }
    }

    public class StockViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Barcode { get; set; }
        public string ProductName { get; set; }
        public decimal CurrentQty { get; set; }
        public decimal HoldQty { get; set; }
        public decimal Rate { get; set; }
        public Unit Unit { get; set; }
        public TaxType TaxRate { get; set; }
        public bool MutliPrice { get; set; }
        public string? HSNCode { get; set; }

    }

    public class StockDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string Barcode { get; set; }

        public decimal PurchaseQty { get; set; }

        public decimal SoldQty { get; set; }
        public decimal HoldQty { get; set; }

        public decimal CostPrice { get; set; }
        public decimal MRP { get; set; }
        public Unit Unit { get; set; }

        [DefaultValue(false)]
        public bool MultiPrice { get; set; }

        public decimal CurrentQty
        { get { return (PurchaseQty - SoldQty - HoldQty); } }

        public decimal CurrentQtyWH
        { get { return (PurchaseQty - SoldQty); } }

        public decimal StockValue
        { get { return (CurrentQty * CostPrice); } }

        public decimal StockValueWH
        { get { return (CurrentQtyWH * CostPrice); } }

        public string StoreId { get; set; }
        public string StoreName { get; set; }
    }
}

