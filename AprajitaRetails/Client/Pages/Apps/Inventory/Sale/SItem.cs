namespace AprajitaRetails.Client.Pages.Apps.Inventory
{
    internal class SItem
    {
        public string Barcode { get; set; }
        public decimal Rate { get; set; }
        public decimal Qty { get; set; }
        public decimal TaxRate { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal Discount { get; set; }
        public decimal Amount { get; set; }
        public Unit Unit { get; set; }
        
    }
}