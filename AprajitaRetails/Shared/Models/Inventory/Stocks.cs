using AprajitaRetails.Shared.Models.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AprajitaRetails.Shared.Models.Inventory
{
    public class Stock : BaseST
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

        [ForeignKey("Barcode")]
        public virtual ProductItem? Product { get; set; }
    }
}