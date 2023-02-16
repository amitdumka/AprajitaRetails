using AprajitaRetails.Shared.Models.Bases;
using AprajitaRetails.Shared.Models.Stores;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AprajitaRetails.Shared.Models.Inventory
{
    public class CustomerSale
    {
        [Key]
        public string InvoiceNumber { get; set; }

        public string MobileNo { get; set; }

        [ForeignKey("MobileNo")]
        public virtual Customer Customer { get; set; }

        [ForeignKey("InvoiceNumber")]
        public virtual ProductSale Sale { get; set; }
    }

    public class PSale
    {
        [Key]
        public string InvoiceNo { get; set; }
        public string InvoiceCode{get;set;}
    }
    public class ProductSale : BaseST
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

        public virtual ICollection<SaleItem> Items { get; set; }
        public bool Paid { get; set; }

        public string SalesmanId { get; set; }
        public bool Tailoring { get; set; }
        public virtual Salesman Salesman { get; set; }
    }
   

public class SaleItem
    {
        public int Id { get; set; }

        public string InvoiceNumber { get; set; }

        public string Barcode { get; set; }

        public decimal BilledQty { get; set; }
        public decimal FreeQty { get; set; }
        public Unit Unit { get; set; }

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

        [ForeignKey("InvoiceNumber")]
        public virtual ProductSale ProductSale { get; set; }

        [ForeignKey("Barcode")]
        public virtual ProductItem ProductItem { get; set; }
    }

    public class SalePaymentDetail
    {
        public int Id { get; set; }
        public string InvoiceNumber { get; set; }
        public decimal PaidAmount { get; set; }
        public PayMode PayMode { get; set; }
        public string RefId { get; set; }

        [ForeignKey("InvoiceNumber")]
        public virtual ProductSale ProductSale { get; set; }
    }

    public class CardPaymentDetail
    {
        public int Id { get; set; }
        public string InvoiceNumber { get; set; }
        public decimal PaidAmount { get; set; }
        public Card Card { get; set; }
        public CardType CardType { get; set; }
        public int CardLastDigit { get; set; }
        public int AuthCode { get; set; }
        public string? EDCTerminalId { get; set; }
        public virtual EDCTerminal PosMachine { get; set; }
    }

     
}